using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Repository
{
    public class TagConnectorRepository : ITagConnectorRepository
    {
        private readonly ApplicationDBContext _context;
        public TagConnectorRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<TagConnector>> GetAllAsync()
        {
            return await _context.TagConnectors.ToListAsync();
        }

        public async Task<TagConnector?> GetByIdAsync(int id)
        {
            return await _context.TagConnectors.FindAsync(id);
        }

        public async Task<TagConnector> CreateAsync(TagConnector tcModel)
        {
            await _context.TagConnectors.AddAsync(tcModel);
            await _context.SaveChangesAsync();
            return tcModel;
        }

        public async Task<TagConnector?> DeleteAsync(int id)
        {
            var tcModel = await  _context.TagConnectors.FirstOrDefaultAsync(x => x.Id == id);
            if(tcModel == null)
            {
                return null;
            }
            _context.TagConnectors.Remove(tcModel);
            await _context.SaveChangesAsync();
            return tcModel;
        }
    }
}