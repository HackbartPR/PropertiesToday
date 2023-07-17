using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries.List;

public class ListPropertyRequestHandler : IRequestHandler<ListPropertyRequest, List<PropertyDto>>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public ListPropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<List<PropertyDto>> Handle(ListPropertyRequest request, CancellationToken cancellationToken)
    {
        List<Property> listProperties = await _propertyRepo.GetAllAsync();
        
        return _mapper.Map<List<PropertyDto>>(listProperties);
    }
}
