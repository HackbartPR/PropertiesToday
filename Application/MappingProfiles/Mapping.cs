using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<NewProperty, Property>();
        CreateMap<UpdateProperty, Property>().ReverseMap();
    }
}
