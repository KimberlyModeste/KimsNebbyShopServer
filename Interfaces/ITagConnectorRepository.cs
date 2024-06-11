using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.Interfaces
{
    public interface ITagConnectorRepository
    {
        Task<List<TagConnector>> GetAllAsync();
        Task<TagConnector?> GetByIdAsync(int id);
        Task<TagConnector> CreateAsync(TagConnector tcModel);
        Task<TagConnector?> DeleteAsync(int id);
    }
}