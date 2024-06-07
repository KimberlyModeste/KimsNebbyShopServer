using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}