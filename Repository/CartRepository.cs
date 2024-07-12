using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.models;
using KimsNebbyShopServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDBContext _context;
        public CartRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateAsync(Cart cartModel)
        {
            await _context.Carts.AddAsync(cartModel);
            await _context.SaveChangesAsync();
            return cartModel;
        }

        public async Task<List<CartItemDto>> GetUserCart(User user)
        {
            return await _context.Carts.Where(e => e.UserId == user.Id)
            .Select(item => new CartItemDto
            {
                Id = item.ItemId,
                Amount = item.Amount,
                Name = item.Item.Name,
                Price = item.Item.Price,
                OnSale = item.Item.OnSale,
                OnSaleBy = item.Item.OnSaleBy                
            }).ToListAsync();
        }
        
        // public async Task<List<Item>> GetUserCart(User user)
        // {
        //     return await _context.Carts.Where(e => e.UserId == user.Id)
        //     .Select(item => new Item 
        //     {
        //         Id = item.ItemId,
        //         Amount = item.Amount,
        //         Name = item.Item.Name,
        //         Price = item.Item.Price,
        //         OnSale = item.Item.OnSale,
        //         OnSaleBy = item.Item.OnSaleBy                
        //     }).ToListAsync();
        // }

    }
}