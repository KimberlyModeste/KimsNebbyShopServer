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
            Console.WriteLine("Here in ImageDTo");
            return new ImageDto {
                Id = imageModel.Id,
                Url = imageModel.Url,
                ItemId = imageModel.ItemId
            };

            // if(imageModel.Item == null)
            // {
            //     return new ImageDto {
            //     Id = imageModel.Id,
            //     Url = imageModel.Url,
            //     ItemId = imageModel.ItemId
            // };
            // }
            // return new ImageDto {
            //     Id = imageModel.Id,
            //     Url = imageModel.Url,
            //     ItemId = imageModel.ItemId,
            //     Item = imageModel.Item.ToItemDto()
            // };
        }

        public static Image ToImageFromCreateDto(this CreateImageDto imageModel)
        {
            return new Image 
            {
                Url = imageModel.Url
            };
        }

        // public static ImageDto ToImageFromCreateDto(this CreateImageDto imageModel)
        // {
        //     return new ImageDto 
        //     {
        //         Url = imageModel.Url,
        //         ItemId = imageModel.ItemId
            
        //     };
        // }
    }
}