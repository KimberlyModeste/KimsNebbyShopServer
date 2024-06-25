using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.TagConnector;
using KimsNebbyShopServer.Models;

namespace KimsNebbyShopServer.mapper
{
    public static class TagConnectorMapper
    {
        public static TagConnectorDto ToTagConnectorDto(this TagConnector tcModel)
        {
            return new TagConnectorDto{
                // Id = tcModel.Id,
                ItemId = tcModel.ItemId,
                TagId = tcModel.TagId
            };
        }

        public static TagConnectorDtoItems ToTagConnectorDtoItems(this TagConnector tcModel)
        {
            if(tcModel.Tag == null)
            {
                return new TagConnectorDtoItems{
                    // Id = tcModel.Id,
                    // ItemId = tcModel.ItemId,
                    TagId = tcModel.TagId
                };
            }
            return new TagConnectorDtoItems{
                // Id = tcModel.Id,
                // ItemId = tcModel.ItemId,
                TagId = tcModel.TagId,
                Tag = tcModel.Tag.ToTagDto()
            };
        }

        // public static TagConnector ToTCFromCreateDto (this CreateTagConnectorRequestDto tcModel, int itemId, int tagId)
        // {
        //     // Console.WriteLine("Before TC Create");
        //     return new TagConnector
        //     {
        //         ItemId = itemId,
        //         TagId = tagId,
        //     };
        // }
    }
}