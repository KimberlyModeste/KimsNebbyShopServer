using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;


namespace KimsNebbyShopServer.Dtos.Image
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public int? ItemId { get; set; }
    }
}