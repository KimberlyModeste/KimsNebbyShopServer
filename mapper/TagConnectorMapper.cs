using System;
using System.Collections.Generic;
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
            if(tcModel.Tag == null || tcModel.Tag.ToTagDto().Name == "")
            {
                return new TagConnectorDto{
                    Id = tcModel.Id,
                    ItemId = tcModel.ItemId,
                    TagId = tcModel.TagId
                };
            }
            return new TagConnectorDto{
                Id = tcModel.Id,
                ItemId = tcModel.ItemId,
                TagId = tcModel.TagId,
                TagName = tcModel.Tag.ToTagDto().Name
            };
        }

        public static TagConnector ToTCFromCreateDto (this CreateTagConnectorRequestDto tcDto)
        {
            return new TagConnector
            {
                ItemId = tcDto.ItemId,
                TagId = tcDto.TagId
            };
        }
    }
}