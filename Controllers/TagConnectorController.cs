using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.TagConnector;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using KimsNebbyShopServer.Models;
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

        //This is where we get one item from the list by the item
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByItemId([FromRoute] int id)
        {
            var tc = await _tcRepo.GetByItemIdAsync(id);
            if(tc == null)
            {
                return NotFound("Connector not found");
            }
            return Ok(tc);
        }
        
        [HttpPost("{itemId:int}-{tagId:int}")]
        public async Task<IActionResult> Create([FromRoute]int itemId, int tagId)
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

            var itemTC = await _tcRepo.GetByItemIdAsync(itemId);
            if(itemTC.Any(e => e.Id == tagId))
            {
                return BadRequest("Tag already exists on item");
            }

            
            var tcModel = new TagConnector
            {
                ItemId = itemId,
                TagId = tagId
            };
            await _tcRepo.CreateAsync(tcModel);

            if(tcModel == null)
            {
                return StatusCode(500, "Could not create");
            }

            return Created();
        }

        [HttpDelete]
        [Route("{itemId:int}-{tagId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int itemId, int tagId)
        {
            var itemTags = await _tcRepo.GetByItemIdAsync(itemId);
            var filterTags = itemTags.Where(s => s.Id == tagId);
            if(filterTags.Count() != 1)
            {
                return NotFound("Connector not found");
            }   

            var tcModel = await _tcRepo.DeleteAsync(itemId, tagId);
            if(tcModel == null)
            {
                return NotFound("Connector not found");
            }
            return NoContent();
        }
    
    }
}