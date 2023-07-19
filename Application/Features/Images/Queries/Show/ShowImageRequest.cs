using Application.Models.Image;
using MediatR;

namespace Application.Features.Images.Queries.Show;

public class ShowImageRequest : IRequest<ImageDto>
{
    public int Id { get; set; }

    public ShowImageRequest(int id)
    {
        Id = id;
    }
}
