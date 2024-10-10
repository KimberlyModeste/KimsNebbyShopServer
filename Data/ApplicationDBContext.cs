using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;
using KimsNebbyShopServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions)
        {
            
        }
        public DbSet<Item> Items { get; set; }
        // public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagConnector> TagConnectors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TagConnector>(x => x.HasKey(y => new {y.ItemId, y.TagId}));
            builder.Entity<TagConnector>()
                .HasOne(i => i.Item)
                .WithMany(i => i.Tags)
                .HasForeignKey(k => k.ItemId);
            builder.Entity<TagConnector>()
                .HasOne(i => i.Tag)
                .WithMany(i => i.Tags)
                .HasForeignKey(k => k.TagId);

            builder.Entity<Cart>(x => x.HasKey(y => new {y.UserId, y.ItemId}));
            builder.Entity<Cart>()
                .HasOne(i => i.User)
                .WithMany(i => i.Carts)
                .HasForeignKey(k => k.UserId);
            builder.Entity<Cart>()
                .HasOne(i => i.Item)
                .WithMany(i => i.Carts)
                .HasForeignKey(k => k.ItemId);
                
            // builder.Entity<Image>()
            // .HasOne(i =>i.Item)
            // .WithMany(i => i.Images)
            // .HasForeignKey(k => k.ItemId);
            builder.Entity<Item>()
                .HasMany(i => i.Images)
                .WithOne(i => i.Item)
                .HasForeignKey(k => k.ItemId);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}