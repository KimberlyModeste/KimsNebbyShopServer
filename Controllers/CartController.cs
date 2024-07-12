using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Extentions;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KimsNebbyShopServer.Controllers
{
    [Route("kimsnebbyshopserver/cart")]
    [ApiController]
    public class CartController : ControllerBase //ALWAYS ADD CONTROLLER BASE BEFORE ROUTE
    {
        private readonly UserManager<User> _userManager;
        private readonly IItemRepository _itemRepo;
        private readonly ICartRepository _cartRepo;
        public CartController(UserManager<User> userManager, IItemRepository itemRepo, ICartRepository cartRepo)
        {
            _userManager = userManager;
            _itemRepo = itemRepo;
            _cartRepo = cartRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserCart()
        {
            var email = User.GetEmail();
            var user = await _userManager.FindByEmailAsync(email);
            var userCart = await _cartRepo.GetUserCart(user);
            return Ok(userCart);
        }
    
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int itemId, int amount)
        {
            var email = User.GetEmail();
            var user = await _userManager.FindByEmailAsync(email);
            var item = await _itemRepo.GetItemByIdAsync(itemId);

            if(item == null) return BadRequest("Item not found");

            var userCart = await _cartRepo.GetUserCart(user);

            if(userCart.Any(e => e.Id == itemId)) return BadRequest("Item Already in cart");
        
            var cartModel = new Cart {
                UserId = user.Id,
                ItemId = item.Id,
                Amount = amount
            };

            await _cartRepo.CreateAsync(cartModel);

            if(cartModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            return Created();

        }
    
    }
}