using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;

namespace KimsNebbyShopServer.Models
{
    [Table("TagConnector")]
    public class TagConnector
    {
        public int TagId { get; set; }
        public int ItemId { get; set; }
        public Tag Tag { get; set; }
        public Item Item { get; set; }
    }
}