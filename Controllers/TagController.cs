using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Tag;
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
        public async Task<IActionResult> GetAll()
        {
            var tag = await _tagRepo.GetAllAsync();
            var tagDto = tag.Select(s => s.ToTagDto());
            return Ok(tagDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tag = await _tagRepo.GetByIdAsync(id);
            if(tag == null)
            {
                return NotFound();
            }
            return Ok(tag.ToTagDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequestDto tagDto)
        {
            var tagModel = tagDto.ToTagFromCreateDto();
            await _tagRepo.CreateAsync(tagModel);
            return CreatedAtAction(nameof(GetById), new { id = tagModel.Id }, tagModel.ToTagDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTagRequestDto updateDto)
        {
            var tagModel = await _tagRepo.UpdateAsync(id, updateDto);
            if(tagModel == null)
            {
                return NotFound();
            }
            return Ok(tagModel.ToTagDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tag = await _tagRepo.DeleteAsync(id);
            if(tag == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}