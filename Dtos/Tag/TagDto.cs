using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.TagConnector;

namespace KimsNebbyShopServer.Dtos.Tag
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }  = string.Empty;
        // public List<TagConnectorDto> Tags { get; set; } = new List<TagConnectorDto> ();
    }
}