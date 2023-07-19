using Application.Models.Image;
using MediatR;

namespace Application.Features.Images.Commands.Update;

public class UpdateImageRequest : IRequest<bool>
{
    public UpdateImage UpdateImage { get; set; }

    public UpdateImageRequest(UpdateImage updateImage)
    {
        UpdateImage = updateImage;
    }
}
