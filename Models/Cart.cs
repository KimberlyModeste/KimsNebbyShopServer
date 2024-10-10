using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;

namespace KimsNebbyShopServer.Models
{
    [Table("Cart")]
    public class Cart
    {
        public int Amount { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public User User { get; set; }
    }
}