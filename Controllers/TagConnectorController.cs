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
        private readonly IItemRepository _itemRepo;
        private readonly ITagRepository _tagRepo;
        public TagConnectorController(ITagConnectorRepository tcRepo, IItemRepository itemRepo, ITagRepository tagRepo)
        {
            _tcRepo = tcRepo;
            _itemRepo = itemRepo;
            _tagRepo = tagRepo; 
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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tc = await _tcRepo.GetByIdAsync(id);
            if(tc == null)
            {
                return NotFound("Connector not found");
            }
            return Ok(tc.ToTagConnectorDto());
        }

        [HttpPost("{itemId:int}-{tagId:int}")]
        public async Task<IActionResult> Create([FromRoute]int itemId, int tagId, CreateTagConnectorRequestDto tcDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var itemExists = await _itemRepo.ItemExists(itemId);
            var tagExists = await _tagRepo.TagExists(tagId);
            if(!itemExists&&!tagExists)
            {
                return BadRequest("Neither item nor tag exists");
            }
            else if (!itemExists)
            {
                return BadRequest("Item does not exist");
            }
            else if (!tagExists)
            {
                return BadRequest("Tag does not exist");
            }
            var tcModel = tcDto.ToTCFromCreateDto(itemId, tagId);
            await _tcRepo.CreateAsync(tcModel);

            return CreatedAtAction(nameof(GetById), new { id = tcModel.Id}, tcModel.ToTagConnectorDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tcModel = await _tcRepo.DeleteAsync(id);
            if(tcModel == null)
            {
                return NotFound("Connector not found");
            }
            return NoContent();
        }
    }
}