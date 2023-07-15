using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<NewPropertyRequest, Property>();
    }
}
