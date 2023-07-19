using MediatR;

namespace Application.Features.Images.Commands.Delete;

public class DeleteImageRequest : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteImageRequest(int id)
    {
        Id = id;
    }
}
