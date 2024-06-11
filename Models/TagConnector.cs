using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;

namespace KimsNebbyShopServer.Models
{
    public class TagConnector
    {
        public int Id { get; set; }
        public int? TagId { get; set; }
        public int? ItemId { get; set; }
        public Tag? Tag { get; set; }
        public Item? Item { get; set; }
    }
}