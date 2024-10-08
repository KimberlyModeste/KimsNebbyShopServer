using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KimsNebbyShopServer.Dtos.Item;
using KimsNebbyShopServer.models;
using Microsoft.IdentityModel.Tokens;


namespace KimsNebbyShopServer.mapper
{
    //This maps the items between database and here
    public static class ItemMapper
    {
        //This brings items from the db to here in the code
        public static ItemDto ToItemDto(this Item itemModel)
        {
            return new ItemDto{
                Id = itemModel.Id,
                Name = itemModel.Name,
                Price = itemModel.Price,
                Description = itemModel.Description,
                OnSale = itemModel.OnSale,
                OnSaleBy = itemModel.OnSaleBy,
                Amount = itemModel.Amount,
                Images = itemModel.Images.Select(s => s.ToImageDto()).ToList(),
                Tags = itemModel.Tags.Select(s => s.ToTagConnectorDtoItems()).ToList()
            };
        }

        //This one creates an item in the code then sends it to the db
        public static Item ToItemFromCreateDto(this CreateItemRequestDto itemDto)
        {
            return new Item
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
                Description = itemDto.Description,
                OnSale = itemDto.OnSale,
                OnSaleBy = itemDto.OnSaleBy,
                Amount = itemDto.Amount,
            };
        }
    }
}