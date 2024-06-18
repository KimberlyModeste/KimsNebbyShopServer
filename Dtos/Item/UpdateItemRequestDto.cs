using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KimsNebbyShopServer.Dtos.Item
{
    public class UpdateItemRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1,100000)]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(bool), "true", "false", ErrorMessage = "OnSale should be either true or false")]
        public bool OnSale { get; set; }

        [Required]
        [Range(0,100)]
        public int OnSaleBy { get; set; }

        [Required]
        [Range(0,1000)]
        public int Amount { get; set; }
    }
}