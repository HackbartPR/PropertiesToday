using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands.Delete;

public class DeletePropertyRequestHandler : IRequestHandler<DeletePropertyRequest, bool>
{
    private readonly IPropertyRepo _propertyRepo;

    public DeletePropertyRequestHandler(IPropertyRepo propertyRepo)
    {
        _propertyRepo = propertyRepo;
    }

    public async Task<bool> Handle(DeletePropertyRequest request, CancellationToken cancellationToken)
    {
        Property property = await _propertyRepo.GetByIdAsync(request.Id);

        if (property == null)
        {
            return false;
        }

        await _propertyRepo.DeleteAsync(property);

        return true;
    }
}
