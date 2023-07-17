using Application.Models;
using MediatR;

namespace Application.Features.Properties.Queries.List;

public class ListPropertyRequest : IRequest<List<PropertyDto>>
{
    public ListPropertyRequest() { }
}
