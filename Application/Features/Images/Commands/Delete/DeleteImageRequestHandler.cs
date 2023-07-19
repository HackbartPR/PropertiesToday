using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands.Delete;

public class DeleteImageRequestHandler : IRequestHandler<DeleteImageRequest, bool>
{
    private readonly IImageRepo _repo;

    public DeleteImageRequestHandler(IImageRepo repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
    {
        Image image = await _repo.GetByIdAsync(request.Id);

        if (image == null)
            return false;

        await _repo.DeleteAsync(image);

        return true;
    }
}
