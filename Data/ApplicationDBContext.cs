using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions)
        {
            
        }
        public DbSet<Item> Items { get; set; }
    }
}