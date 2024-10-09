using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.models;

namespace KimsNebbyShopServer.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}