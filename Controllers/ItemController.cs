using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Helpers;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KimsNebbyShopServer.controllers
{
    //This is the route for all things items
    [Route("kimsnebbyshopserver/item")]
    [ApiController]
    public class ItemController : ControllerBase //ALWAYS ADD CONTROLLER BASE BEFORE ROUTE
    {
        private readonly IItemRepository _itemRepo;
        public ItemController(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        //This is where we get all of the items in the list
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var items = await _itemRepo.GetAllAsync(query);
            var itemDto = items.Select(s => s.ToItemDto());
            return Ok(itemDto);
        }

        //This is where we get one item from the list
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var item = await _itemRepo.GetItemByIdAsync(id);
            if(item == null)
            {
                return NotFound("Item not found");
            }
            return Ok(item.ToItemDto());
        }

        //This is where we put new things into the database
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemRequestDto itemDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var itemModel = itemDto.ToItemFromCreateDto();
            await _itemRepo.CreateAsync(itemModel);
            return CreatedAtAction(nameof(GetById), new { id = itemModel.Id}, itemModel.ToItemDto());
        }

        //This is where we change something in a database
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateItemRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var itemModel = await _itemRepo.UpdateAsync(id, updateDto);
            if(itemModel == null)
            {
                return NotFound("Item not found");
            }
            return Ok(itemModel.ToItemDto());
        }
        //This is where we delete something in a database
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = await _itemRepo.DeleteAsync(id);
            if(item == null)
            {
                return NotFound("Item not found");
            }
            return NoContent();
        }
    }
}