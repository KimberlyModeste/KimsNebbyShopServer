using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Image;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllAsync ();
        Task<Image?> GetByIdAsync(int id);
        Task<List<ImageDto>> GetImageByItemIdAsync(int id); //The question mark is for the id
        Task<Image> CreateAsync(Image imageModel);
        // Task<Image?> UpdateAsync(int id, UpdateItemRequestDto itemDto);
        Task<Image?> DeleteAsync(int id);
        Task<bool> ImageExists(int id);
    }
}