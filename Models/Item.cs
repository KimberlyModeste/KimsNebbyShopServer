using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KimsNebbyShopServer.models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public int OnSaleBy { get; set; }
        public string Tags { get; set; } = string.Empty;
        public int Amount { get; set; }
        // public List<string> Tags { get; set; } = new List<string>{string.Empty};
    }
}