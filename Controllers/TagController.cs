using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Tag;
using KimsNebbyShopServer.Helpers;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using Microsoft.AspNetCore.Mvc;

namespace KimsNebbyShopServer.Controllers
{
    [Route("kimsnebbyshopserver/tag")]
    [ApiController]

    public class TagController : ControllerBase //ADD THIS FIRST BEFORE THE ROUTE
    {
        private readonly ITagRepository _tagRepo;

        public TagController(ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var tag = await _tagRepo.GetAllAsync(query);
            var tagDto = tag.Select(s => s.ToTagDto());
            return Ok(tagDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tag = await _tagRepo.GetByIdAsync(id);
            if(tag == null)
            {
                return NotFound("Tag not found");
            }
            return Ok(tag.ToTagDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequestDto tagDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var tagModel = tagDto.ToTagFromCreateDto();
            await _tagRepo.CreateAsync(tagModel);
            return CreatedAtAction(nameof(GetById), new { id = tagModel.Id }, tagModel.ToTagDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTagRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var tagModel = await _tagRepo.UpdateAsync(id, updateDto);
            if(tagModel == null)
            {
                return NotFound("Tag not found");
            }
            return Ok(tagModel.ToTagDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tag = await _tagRepo.DeleteAsync(id);
            if(tag == null)
            {
                return NotFound("Tag not found");
            }
            return NoContent();
        }
    }
}