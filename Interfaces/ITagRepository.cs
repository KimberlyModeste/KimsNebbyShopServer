using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Tag;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag> CreateAsync(Tag tagModel);
        Task<Tag?> UpdateAsync(int id, UpdateTagRequestDto itemDto);
        Task<Tag?> DeleteAsync(int id);
        Task<bool> TagExists(int id);
    }
}