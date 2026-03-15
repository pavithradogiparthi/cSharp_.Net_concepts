using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingConfig
{
    public class Mappings:Profile
    {
        public Mappings()
            {
            CreateMap<NewProperty, Property>().ReverseMap();
            CreateMap<Property,PropertyDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<NewImage, Image>().ReverseMap();
        }
    }
}
