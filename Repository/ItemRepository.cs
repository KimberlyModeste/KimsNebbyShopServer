using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Dtos.Tag;
using KimsNebbyShopServer.Helpers;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.mapper;
using KimsNebbyShopServer.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDBContext _context;
        public ItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync(QueryObject query)
        {
            var item = _context.Items.Include(x => x.Tags).ThenInclude(y =>y.Tag).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                item = item.Where(x => x.Name.Contains(query.Name));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    item = query.isDecsending ? item.OrderByDescending(x => x.Name) : item.OrderBy(x => x.Name);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;



            return await item.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _context.Items.Include(x => x.Tags).ThenInclude(y =>y.Tag).FirstOrDefaultAsync(z => z.Id == id);
        }
        
        public async Task<Item> CreateAsync(Item itemModel)
        {
            await _context.Items.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<Item?> UpdateAsync(int id, UpdateItemRequestDto itemDto)
        {
            var itemModel = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(itemModel == null)
            {
                return null;
            }

            itemModel.Name = itemDto.Name == "" || itemDto.Name == "string" ? itemModel.Name : itemDto.Name;
            itemModel.Price = itemDto.Price == 0 ? itemModel.Price : itemDto.Price;
            itemModel.OnSale = itemDto.OnSale;
            itemModel.OnSaleBy = itemDto.OnSaleBy == -1 ? itemModel.OnSaleBy : itemDto.OnSaleBy;
            itemModel.Amount = itemDto.Amount == -1 ? itemModel.Amount : itemDto.Amount;

            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<Item?> DeleteAsync(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            
            if(item == null)
            {
                return null;
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            
            return item;
        }

        public Task<bool> ItemExists(int id)
        {
            return _context.Items.AnyAsync(x => x.Id==id);
        }
    }
}