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
        public string TagName { get; set; } = string.Empty;
        public Tag? Tag { get; set; } = new Tag();
        public Item? Item { get; set; }  = new Item();
    }
}