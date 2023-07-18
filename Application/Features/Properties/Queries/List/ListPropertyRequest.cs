using Application.Models.Property;
using MediatR;

namespace Application.Features.Properties.Queries.List;

public class ListPropertyRequest : IRequest<List<PropertyDto>>
{
    public ListPropertyRequest() { }
}
