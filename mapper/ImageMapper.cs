using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Image;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.mapper
{
    public static class ImageMapper
    {
        public static ImageDto ToImageDto(this Image imageModel)
        {
            return new ImageDto {
                Id = imageModel.Id,
                Url = imageModel.Url,
                ItemId = imageModel.ItemId
            };
        }

        public static Image ToImageFromCreateDto(this CreateImageDto imageModel)
        {
            return new Image 
            {
                Url = imageModel.Url
            };
        }
    }
}