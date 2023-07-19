using Application.Models.Image;
using MediatR;

namespace Application.Features.Images.Queries.List;

public class ListImageRequest : IRequest<List<ImageDto>>
{
}
