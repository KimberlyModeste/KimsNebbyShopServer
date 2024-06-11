using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Dtos.Tag;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDBContext _context;
        public TagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag> CreateAsync(Tag tagModel)
        {
            await _context.Tags.AddAsync(tagModel);
            await _context.SaveChangesAsync();
            return tagModel;
        }

        public async Task<Tag?> UpdateAsync(int id, UpdateTagRequestDto tagDto)
        {
            var tagModel = await _context.Tags.FirstOrDefaultAsync(x => x.Id==id);
            if(tagModel == null)
            {
                return null;
            }

            tagModel.Name = tagDto.Name == "" || tagDto.Name == "string" ? tagModel.Name : tagDto.Name;
            await _context.SaveChangesAsync();
            return tagModel;
        }

        public async Task<Tag?> DeleteAsync(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x =>x.Id==id);

            if(tag == null)
            {
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }
        
        public Task<bool> TagExists(int id)
        {
            return _context.Tags.AnyAsync(s => s.Id==id);
        }
    }
}