using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Dtos.Image;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDBContext _context;
        public ImageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }
        
        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }
        
        public async Task<List<ImageDto>> GetImageByItemIdAsync(int id)
        {
            return await _context.Images.Where(u => u.ItemId == id)
            .Select(i => new ImageDto{
                Id = i.Id,
                Url = i.Url,
                ItemId = i.ItemId
            }).ToListAsync();
        }
        
        public async Task<Image> CreateAsync(Image imageModel)
        {
            await _context.Images.AddAsync(imageModel);
            await _context.SaveChangesAsync();
            return imageModel;
        }

        public async Task<Image?> UpdateAsync(int id, UpdateImageRequestDto imageDto)
        {
            var imageModel = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
            if(imageModel == null)
            {
                return null;
            }

            imageModel.Url = imageDto.Url == "" || imageDto.Url == "string" ? imageModel.Url : imageDto.Url;
            await _context.SaveChangesAsync();
            return imageModel;
        }
        
        public async Task<Image?> DeleteAsync(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
            
            if(image == null)
            {
                return null;
            }
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return image;
        }

        // public Task<bool> ImageExists(int id)
        // {
        //     return _context.Images.AnyAsync(x => x.Id==id);
        // }
    }
}