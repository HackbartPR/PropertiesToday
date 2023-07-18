using MediatR;

namespace Application.Features.Properties.Commands.Delete;

public class DeletePropertyRequest : IRequest<bool>
{
    public int Id { get; set; }

    public DeletePropertyRequest(int id)
    {
        Id = id;
    }
}
