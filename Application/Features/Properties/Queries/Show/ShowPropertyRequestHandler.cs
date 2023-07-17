using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries.Show;

public class ShowPropertyRequestHandler : IRequestHandler<ShowPropertyRequest, ShowProperty>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public ShowPropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<ShowProperty> Handle(ShowPropertyRequest request, CancellationToken cancellationToken)
    {
        Property property = await _propertyRepo.GetByIdAsync(request.Id);        

        return _mapper.Map<ShowProperty>(property);
    }
}
