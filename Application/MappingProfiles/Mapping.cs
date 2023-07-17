using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<NewProperty, Property>().ReverseMap();
        CreateMap<UpdateProperty, Property>().ReverseMap();
        CreateMap<PropertyDto, Property>().ReverseMap();
    }
}
