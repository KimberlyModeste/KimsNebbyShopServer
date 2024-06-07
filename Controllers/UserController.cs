using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using Microsoft.AspNetCore.Mvc;

namespace KimsNebbyShopServer.Controllers
{
    [Route("kimsnebbyshopserver/user")]
    [ApiController]
    public class UserController : ControllerBase //ADD THIS FIRST BEFORE THE ROUTE
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            var userDto = users.Select(s => s.ToUserDto());
            return Ok(userDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }
    }
}