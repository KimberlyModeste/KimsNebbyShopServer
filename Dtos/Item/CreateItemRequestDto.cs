using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Tag;

namespace KimsNebbyShopServer.Dtos.Item
{
    //This is the create item dto the format for putting things into the database
    public class CreateItemRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public int OnSaleBy { get; set; }
        public int Amount { get; set; }
    }
}