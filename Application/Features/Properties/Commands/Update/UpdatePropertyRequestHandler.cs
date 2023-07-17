using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands.Update;

public class UpdatePropertyRequestHandler : IRequestHandler<UpdatePropertyRequest, bool>
{
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
    {
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
    {
        Property property = await _propertyRepo.GetByIdAsync(request.UpdateProperty.Id);

        if (property == null)
        {
            return false;
        }

        _mapper.Map(request.UpdateProperty, property);

        await _propertyRepo.UpdateAsync(property);

        return true;
    }
}
