using Application.Models.Image;
using Application.Models.Property;
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

        CreateMap<NewImage, Image>().ReverseMap();
        CreateMap<UpdateImage, Image>().ReverseMap();
    }
}
