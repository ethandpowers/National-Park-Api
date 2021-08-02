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
    public class SpeciesController : ControllerBase
    {
        private readonly NpContext _context;
        public SpeciesController(NpContext context)
        {
            _context = context;
        }

        //returns the species with the matching species id.  NOT a matching ID property, which is for database use only
        [HttpGet("byId")]
        public IActionResult GetBySpeciesID(string id)
        {
            if(id == null || !_context.Species.Where(s => s.Species_ID == id).Any())
            {
                return BadRequest("No species with that id");
            }
            try
            {
                Species species = _context.Species.Where(s => s.Species_ID == id).Include(s => s.Common_Names).FirstOrDefault();
                return Ok(new SpeciesVM(species));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of species within the specified category
        [HttpGet("byCategory")]
        public IActionResult GetByCategory(string category)
        {
            if (category == null || !_context.Species.Where(s => s.Category.Contains(category)).Any())
            {
                return BadRequest("No species in that category");
            }
            try
            {
                List<Species> speciesList = _context.Species.Where(s => s.Category.Contains(category)).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach(var species in speciesList)
                {
                    listVM.Add(new SpeciesVM(species));
                }

                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of species within the specified order
        [HttpGet("byOrder")]
        public IActionResult GetByOrder(string order)
        {
            if (order == null || !_context.Species.Where(s => s.Order == order).Any())
            {
                return BadRequest("No species in that order");
            }
            try
            {
                List<Species> speciesList = _context.Species.Where(s => s.Order == order).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var species in speciesList)
                {
                    listVM.Add(new SpeciesVM(species));
                }

                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of species within the specified family
        [HttpGet("byFamily")]
        public IActionResult GetByFamily(string family)
        {
            if (family == null || !_context.Species.Where(s => s.Family == family).Any())
            {
                return BadRequest("No species in that family");
            }
            try
            {
                List<Species> speciesList = _context.Species.Where(s => s.Family == family).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var species in speciesList)
                {
                    listVM.Add(new SpeciesVM(species));
                }

                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        //returns a list of species which contains the name input in the scientific name
        [HttpGet("byScientificName")]
        public IActionResult GetByScientificName(string name)
        {
            if(name == null || !_context.Species.Where(s => s.Scientific_Name.Contains(name)).Any())
            {
                return BadRequest("No species with that name");
            }
            try
            {
                List<Species> species = _context.Species.Where(s => s.Scientific_Name.Contains(name)).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach(var sp in species)
                {
                    listVM.Add(new SpeciesVM(sp));
                }
                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of species which have a certain conservation status
        [HttpGet("byConservationStatus")]
        public IActionResult GetByStatus(string status)
        {
            if (status == null || !_context.Species.Where(s => s.Conservation_Status == status).Any())
            {
                return BadRequest("No such category");
            }
            try
            {
                List<Species> species = _context.Species.Where(s => s.Conservation_Status == status).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var sp in species)
                {
                    listVM.Add(new SpeciesVM(sp));
                }
                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of species which have a certain seasonality
        [HttpGet("bySeasonality")]
        public IActionResult GetBySeasonality(string seasonality)
        {
            if (seasonality == null || !_context.Species.Where(s => s.Seasonality == seasonality).Any())
            {
                return BadRequest("No such seasonality");
            }
            try
            {
                List<Species> species = _context.Species.Where(s => s.Seasonality == seasonality).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var sp in species)
                {
                    listVM.Add(new SpeciesVM(sp));
                }
                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //returns a list of species which have a certain abundance
        [HttpGet("byAbundance")]
        public IActionResult GetByAbundance(string abundance)
        {
            if (abundance == null || !_context.Species.Where(s => s.Abundance == abundance).Any())
            {
                return BadRequest("No such abundance");
            }
            try
            {
                List<Species> species = _context.Species.Where(s => s.Abundance == abundance).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var sp in species)
                {
                    listVM.Add(new SpeciesVM(sp));
                }
                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("byCommonName")]
        public IActionResult GetByCommonName(string name)
        {
            if (name == null || !_context.Species.Where(s => s.Common_Names.Where(c => c.Name.Contains(name)).Any()).Any())
            {
                return BadRequest("No such species");
            }
            try
            {
                List<Species> species = _context.Species.Where(s => s.Common_Names.Where(c => c.Name.Contains(name)).Any()).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var sp in species)
                {
                    listVM.Add(new SpeciesVM(sp));
                }
                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("byPark")]
        public IActionResult GetByPark(string park)
        {
            if (park == null || !_context.Species.Where(s => s.Park.Contains(park)).Any())
            {
                return BadRequest("No such species");
            }
            try
            {
                List<Species> species = _context.Species.Where(s => s.Park.Contains(park)).Include(s => s.Common_Names).ToList();
                List<SpeciesVM> listVM = new List<SpeciesVM>();
                foreach (var sp in species)
                {
                    listVM.Add(new SpeciesVM(sp));
                }
                return Ok(listVM);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
