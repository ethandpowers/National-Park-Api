using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParkApi.Data;
using NationalParkApi.Models;
using NationalParkApi.Models.DTO_s;
using System.Collections.Generic;
using System.Linq;

namespace NationalParkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatParkController : ControllerBase
    {
        private readonly NpContext _context;
        public NatParkController(NpContext context)
        {
            _context = context;
        }

        //used to test the database initialization NOT FOR USE!!
        [HttpGet("test")]
        public IActionResult InitTest()
        {
            //DbInit.Initialize(_context);
            //return Ok(_context.Parks.Include(p => p.States)
            //        .Include(p => p.Categories)
            //        .ThenInclude(c => c.Orders)
            //        .ThenInclude(o => o.Families)
            //        .ThenInclude(f => f.Species)
            //        .ThenInclude(s => s.Common_Names));
            return Ok();
        }

        //returns the data for a park(list) described by the park's unique code
        [HttpGet("byParkCode")]
        public IActionResult GetByCode(string code)
        {
            if (code == null || !_context.Parks.Where(p => p.Code == code).Any())
            {
                return BadRequest("Plase enter a valid code");
            }
            try
            {
                Park currentPark = _context.Parks.Where(p => p.Code == code)
                    .Include(p => p.States)
                    .Include(p => p.Categories)
                    .ThenInclude(c => c.Orders)
                    .ThenInclude(o => o.Families)
                    .ThenInclude(f => f.Species)
                    .ThenInclude(s => s.Common_Names)
                    .FirstOrDefault();

                return Ok(new List<ParkVM>{new ParkVM(currentPark)});
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns the data for a park(list) described by the park's name
        [HttpGet("byParkName")]
        public IActionResult GetByName(string name)
        {
            if (name == null || !_context.Parks.Where(p => p.Name.Contains(name)).Any())
            {
                return BadRequest("Plase enter a valid name");
            }
            try
            {
                List<ParkVM> finalList = new List<ParkVM>();
                List<Park> parkList = _context.Parks.Where(p => p.Name.Contains(name))
                    .Include(p => p.States)
                    .Include(p => p.Categories)
                    .ThenInclude(c => c.Orders)
                    .ThenInclude(o => o.Families)
                    .ThenInclude(f => f.Species)
                    .ThenInclude(s => s.Common_Names).ToList();

                foreach(var park in parkList)
                {
                    finalList.Add(new ParkVM(park));
                }
                return Ok(finalList);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of the parks within a given state
        [HttpGet("byState")]
        public IActionResult GetByState(string state, bool? includeData = false)
        {
            if (state == null || !_context.Parks.Where(p => p.States.Where(s => s.Name == state).Any()).Any())
            {
                return BadRequest("No parks listed for this state");
            }
            try
            {
                if (includeData.HasValue && includeData.Value)
                {
                    List<Park> parks = _context.Parks.Where(p => p.States.Where(s => s.Name == state).Any())
                        .Include(p => p.States)
                        .Include(p => p.Categories)
                        .ThenInclude(c => c.Orders)
                        .ThenInclude(o => o.Families)
                        .ThenInclude(f => f.Species)
                        .ThenInclude(s => s.Common_Names).ToList();

                    List<ParkVM> parksVM = new List<ParkVM>();
                    foreach(var park in parks)
                    {
                        parksVM.Add(new ParkVM(park));
                    }
                    return Ok(parksVM);
                }
                else
                {
                    List<Park> parks = _context.Parks.Where(p => p.States.Where(s => s.Name == state).Any()).Include(p => p.States).ToList();
                    List<ParkVM> parksVM = new List<ParkVM>();
                    foreach (var park in parks)
                    {
                        parksVM.Add(new ParkVM(park));
                    }
                    return Ok(parksVM);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
