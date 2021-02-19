using System;
using System.Threading.Tasks;
using DataService.models;
using DataService.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly AbstractDAO<Sector> sectorDAO;

        public SectorController(AbstractDAO<Sector> sectorDAO)
        {
            this.sectorDAO = sectorDAO;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetAllSectors()
        {
            var appSectors = await sectorDAO.GetAll();

            if (appSectors.Count != 0)
                return Ok(appSectors);

            return NotFound("No employee exit yet.");
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetById(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
                return BadRequest("Id must not be empty");
            var sector = await sectorDAO.GetById(id);
            if (sector == null)
            {
                return NotFound($"Sector with Id {id} doesn't exit");
            }
            return Ok(sector);
        }
        
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Sector sector)
        {
            if (sector == null)
                return BadRequest("Sector not passed");

            var createdSector = await sectorDAO.Create(sector);

            if (createdSector != null)
            {
                return CreatedAtAction("GetById", "Sector", new { createdSector.Id }, createdSector);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }
        }
    }
}