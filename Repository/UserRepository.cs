using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.data;
using KimsNebbyShopServer.Interfaces;
using KimsNebbyShopServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Repository
{
    public class UserRepository : IUserRepository
    {
        // private readonly ApplicationDBContext _context;
        // public UserRepository(ApplicationDBContext context)
        // {
        //     _context = context;
        // }
        // public async Task<List<User>> GetAllAsync()
        // {
        //     return await _context.Users.ToListAsync();
        // }

        // public async Task<User?> GetByIdAsync(int id)
        // {
        //     return await _context.Users.FindAsync(id);
        // }
    }
}