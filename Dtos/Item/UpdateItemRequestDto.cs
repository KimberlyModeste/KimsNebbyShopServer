using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimsNebbyShopServer.Dtos.Item
{
    public class UpdateItemRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public int OnSaleBy { get; set; }
        public int Amount { get; set; }
    }
}