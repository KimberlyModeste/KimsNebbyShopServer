using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.models;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.Interfaces
{
    public interface ICartRepository
    {
        // Task<List<Item>> GetUserCart(User user);
        Task<List<CartItemDto>> GetUserCart(User user);
        Task<Cart> CreateAsync(Cart cartModel);
    }
}