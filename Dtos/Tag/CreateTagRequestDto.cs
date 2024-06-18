using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KimsNebbyShopServer.Dtos.Tag
{
    public class CreateTagRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
        public string Name { get; set; } = string.Empty;
    }
}