using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Image;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using KimsNebbyShopServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KimsNebbyShopServer.Controllers
{
    [Route("kimsnebbyshopserver/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public readonly IImageRepository _imageRepo;
        public readonly IItemRepository _itemRepo;

        public ImageController(IImageRepository imageRepo, IItemRepository itemRepo)
        {
            _imageRepo = imageRepo;
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var image = await _imageRepo.GetAllAsync();
            var imgDto = image.Select(s => s.ToImageDto());
            return Ok(imgDto);
        }

        // This is where we get one item from the list by the item
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var image = await _imageRepo.GetImageByItemIdAsync(id);
            if(image == null)
            {
                return NotFound("Connector not found");
            }
            return Ok(image);
        }
        
        //This is where we put new things into the database
        [HttpPost("{itemId:int}")]
        public async Task<IActionResult> Create([FromRoute] int itemId, [FromBody] CreateImageDto imageDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemExists = await _itemRepo.ItemExists(itemId);

            if(!itemExists)
            {
                return BadRequest("Item does not exist");
            }

            var itemImg = await _imageRepo.GetImageByItemIdAsync(itemId);
            if(itemImg.Any(e => e.Url== imageDto.Url ))
            {
                return BadRequest("Image already exists on an item");
            }

            var imgModel = new Image {
                ItemId = itemId,
                Url = imageDto.Url
            };
            await _imageRepo.CreateAsync(imgModel);
            if (imgModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            return Created();
        }
        
        //This is where we change something in a database
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateImageRequestDto updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageModel = await _imageRepo.UpdateAsync(id, updateDto);
            if(imageModel == null)
            {
                return NotFound("Image not found");
            }
            return Ok(imageModel.ToImageDto());
        }

         //This is where we delete something in a database
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var image = await _imageRepo.DeleteAsync(id);
            if(image == null)
            {
                return NotFound("Image not found");
            }
            return NoContent();
        }

    }
}