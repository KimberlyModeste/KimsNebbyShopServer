using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimsNebbyShopServer.Dtos.TagConnector
{
    public class CreateTagConnectorRequestDto
    {
        public int TagId { get; set; }
        public int ItemId { get; set; }
    }
}