using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Tag;

namespace KimsNebbyShopServer.Dtos.Item
{
    //This is the create item dto the format for putting things into the database
    public class CreateItemRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1,100000, ErrorMessage = "Decimal isn't within the range")]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
        public bool OnSale { get; set; }

        [Required]
        [Range(0,100, ErrorMessage = "OnSaleBy isn't in the rage of 0 - 100")]
        public int OnSaleBy { get; set; }

        [Required]
        [Range(0,1000, ErrorMessage = "Amount Range isn't between 0 - 1000")]
        public int Amount { get; set; }
    }
}