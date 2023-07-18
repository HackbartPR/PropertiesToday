using Application.Models.Image;
using MediatR;

namespace Application.Features.Images.Commands.Create;

public class CreateImageRequest : IRequest<bool>
{
    public NewImage NewImage { get; set; }

    public CreateImageRequest(NewImage newImage)
    {
        NewImage = newImage;
    }
}
