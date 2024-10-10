using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.models;


namespace KimsNebbyShopServer.Dtos.Image
{
    public class ImageDto
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        // [ForeignKey("Item")]
        public int? ItemId { get; set; }
        // public ItemDto? Item { get; set; } = new ItemDto();
    }
}