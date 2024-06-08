using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Dtos.Tag;
using Microsoft.EntityFrameworkCore;

namespace KimsNebbyShopServer.Dtos.TagConnector
{
    public class TagConnectorDto
    {
        public int Id { get; set; }
        public int? TagId { get; set; }
        public int? ItemId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public TagDto? Tag { get; set; } = new TagDto();
        // public ItemDto? Item { get; set; }  = new ItemDto();
    }
}