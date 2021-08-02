using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParkApi.Data;
using NationalParkApi.Models;
using NationalParkApi.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly NpContext _context;

        public TrailsController(NpContext context)
        {
            this._context = context;
        }

        //returns the trail with the matching species id.  NOT a matching ID property, which is for database use only
        [HttpGet("byId")]
        public IActionResult GetByTrailId(string id)
        {

            if (id == null || !_context.Trails.Where(t => t.trailID == id).Any())
            {
                return BadRequest("No trails with that id");
            }
            try
            {
                Trail trail = _context.Trails.Where(t => t.trailID == id).Include(t => t.features).Include(t => t.activities).FirstOrDefault();
                return Ok(new TrailVM(trail));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns the trails with the matching name.
        [HttpGet("byName")]
        public IActionResult GetByName(string name)
        {

            if (name == null || !_context.Trails.Where(t => t.name.ToLower().Contains(name.ToLower())).Any())
            {
                return BadRequest("No trails with that name");
            }
            try
            {
                List<Trail> trails = _context.Trails.Where(t => t.name.ToLower().Contains(name.ToLower())).Include(t => t.features).Include(t => t.activities).ToList();
                List<TrailVM> trailsVM = new List<TrailVM>();
                foreach (Trail trail in trails)
                {
                    trailsVM.Add(new TrailVM(trail));
                }
                return Ok(trailsVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns the trails with the matching area.
        [HttpGet("byArea")]
        public IActionResult GetByArea(string area)
        {

            if (area == null || !_context.Trails.Where(t => t.areaName.ToLower().Contains(area.ToLower())).Any())
            {
                return BadRequest("No trails with that area");
            }
            try
            {
                List<Trail> trails = _context.Trails.Where(t => t.areaName.ToLower().Contains(area.ToLower())).Include(t => t.features).Include(t => t.activities).ToList();
                List<TrailVM> trailsVM = new List<TrailVM>();
                foreach (Trail trail in trails)
                {
                    trailsVM.Add(new TrailVM(trail));
                }
                return Ok(trailsVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        //returns the trails with the matching city.
        [HttpGet("byCity")]
        public IActionResult GetByCity(string city)
        {

            if (city == null || !_context.Trails.Where(t => t.cityName.ToLower().Contains(city.ToLower())).Any())
            {
                return BadRequest("No trails with that city");
            }
            try
            {
                List<Trail> trails = _context.Trails.Where(t => t.cityName.ToLower().Contains(city.ToLower())).Include(t => t.features).Include(t => t.activities).ToList();
                List<TrailVM> trailsVM = new List<TrailVM>();
                foreach (Trail trail in trails)
                {
                    trailsVM.Add(new TrailVM(trail));
                }
                return Ok(trailsVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns the trails that contain the given feature.
        [HttpGet("byFeature")]
        public IActionResult GetByFeature(string feature)
        {

            if (feature == null || !_context.Trails.Where(t => t.features.Where(f => f.feature.ToLower().Contains(feature.ToLower())).Any()).Any())
            {
                return BadRequest("No trails with that feature");
            }
            try
            {
                List<Trail> trails = _context.Trails.Where(t => t.features.Where(f => f.feature.ToLower().Contains(feature.ToLower())).Any()).Include(t => t.features).Include(t => t.activities).ToList();
                List<TrailVM> trailsVM = new List<TrailVM>();
                foreach (Trail trail in trails)
                {
                    trailsVM.Add(new TrailVM(trail));
                }
                return Ok(trailsVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns the trails that contain the given activity.
        [HttpGet("byActivity")]
        public IActionResult GetByActivity(string activity)
        {

            if (activity == null || !_context.Trails.Where(t => t.activities.Where(f => f.activity.ToLower().Contains(activity.ToLower())).Any()).Any())
            {
                return BadRequest("No trails with that activity");
            }
            try
            {
                List<Trail> trails = _context.Trails.Where(t => t.activities.Where(f => f.activity.ToLower().Contains(activity.ToLower())).Any()).Include(t => t.features).Include(t => t.activities).ToList();
                List<TrailVM> trailsVM = new List<TrailVM>();
                foreach (Trail trail in trails)
                {
                    trailsVM.Add(new TrailVM(trail));
                }
                return Ok(trailsVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
