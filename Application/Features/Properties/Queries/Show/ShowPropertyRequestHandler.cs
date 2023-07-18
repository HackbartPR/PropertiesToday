using Application.Models.Property;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries.Show;

public class ShowPropertyRequestHandler : IRequestHandler<ShowPropertyRequest, PropertyDto>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public ShowPropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<PropertyDto> Handle(ShowPropertyRequest request, CancellationToken cancellationToken)
    {
        Property property = await _propertyRepo.GetByIdAsync(request.Id);        

        return _mapper.Map<PropertyDto>(property);
    }
}
