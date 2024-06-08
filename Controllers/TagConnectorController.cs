using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.TagConnector;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using Microsoft.AspNetCore.Mvc;

namespace KimsNebbyShopServer.Controllers
{
    [Route("kimsnebbyshopserver/tagcontrol")]
    [ApiController]

    public class TagConnectorController: ControllerBase //ALWAYS ADD CONTROLLER BASE BEFORE ROUTE
    {
        private readonly ITagConnectorRepository _tcRepo;
        public TagConnectorController(ITagConnectorRepository tcRepo)
        {
            _tcRepo = tcRepo;
        }
        
        //This is where we get all of the items in the list
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tc = await _tcRepo.GetAllAsync();
            var tcDto = tc.Select(s => s.ToTagConnectorDto());
            return Ok(tcDto);
        }

        //This is where we get one item from the list
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tc = await _tcRepo.GetByIdAsync(id);
            if(tc == null)
            {
                return NotFound();
            }
            return Ok(tc.ToTagConnectorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagConnectorRequestDto tcDto)
        {
            var tcModel = tcDto.ToTCFromCreateDto();
            await _tcRepo.CreateAsync(tcModel);
            return CreatedAtAction(nameof(GetById), new { id = tcModel.Id}, tcModel.ToTagConnectorDto());
        }
    }
}