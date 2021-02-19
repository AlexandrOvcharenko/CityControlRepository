using System;
using System.Threading.Tasks;
using DataService.models;
using DataService.Models;
using DataService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly AbstractDAO<House> houseDAO;

        public HouseController(AbstractDAO<House> houseDAO)
        {
            this.houseDAO = houseDAO;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetAllSectors()
        {
            var appSectors = await houseDAO.GetAll();

            if (appSectors.Count != 0)
                return Ok(appSectors);

            return NotFound("No house exist yet.");
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetById(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
                return BadRequest("Id must not be empty");
            var sector = await houseDAO.GetById(id);
            if (sector == null)
            {
                return NotFound($"House with Id {id} doesn't exit");
            }
            return Ok(sector);
        }
        
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(House house)
        {
            if (house == null)
                return BadRequest("House not passed");

            var createdHouse = await houseDAO.Create(house);

            if (createdHouse != null)
            {
                return CreatedAtAction("GetById", "House", new { createdHouse.Id }, createdHouse);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }
        }
    }
}