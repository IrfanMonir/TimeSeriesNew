using Application.Buildings;
using Application.Buildings.Command;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Building, BuildingDto>();
            CreateMap<BuildingDto, Building>();// means you want to map from User to UserDTO
            CreateMap<Building, CreateBuilding>();// means you want to map from User to UserDTO
            CreateMap<CreateBuilding, Building>();// means you want to map from User to UserDTO
        }
    }
}
