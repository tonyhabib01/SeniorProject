using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GymApplication.Models;
using GymApplication.Dtos;

namespace GymApplication.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Item, ItemDto>();
            Mapper.CreateMap<ItemDto, Item>();
        }
    }
}