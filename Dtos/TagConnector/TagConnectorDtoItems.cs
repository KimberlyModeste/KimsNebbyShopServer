using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.Dtos.Tag;

namespace KimsNebbyShopServer.Dtos.TagConnector
{
    public class TagConnectorDtoItems
    {
        public int Id { get; set; }
        public int? TagId { get; set; }
        public int? ItemId { get; set; }
        public TagDto? Tag { get; set; } = new TagDto();
    }
}