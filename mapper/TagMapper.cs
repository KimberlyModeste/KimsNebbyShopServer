using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Tag;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.mapper
{
    public static class TagMapper
    {
        public static TagDto ToTagDto(this Tag tagModel)
        {
            return new TagDto{
                Id = tagModel.Id,
                Name = tagModel.Name
            };
        }
    }
}