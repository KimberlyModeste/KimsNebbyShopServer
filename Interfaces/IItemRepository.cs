using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Helpers;
using KimsNebbyShopServer.models;

namespace KimsNebbyShopServer.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync (QueryObject query);
        Task<Item?> GetItemByIdAsync(int id); //The question mark is for the id
        Task<Item> CreateAsync(Item itemModel);
        Task<Item?> UpdateAsync(int id, UpdateItemRequestDto itemDto);
        Task<Item?> DeleteAsync(int id);
        Task<bool> ItemExists(int id);

    }
}