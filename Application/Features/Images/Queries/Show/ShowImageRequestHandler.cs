using Application.Models.Image;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries.Show;

public class ShowImageRequestHandler : IRequestHandler<ShowImageRequest, ImageDto>
{
    private readonly IImageRepo _imageRepo;
    private readonly IMapper _mapper;
    public ShowImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
    {
        _imageRepo = imageRepo;
        _mapper = mapper;
    }

    public async Task<ImageDto> Handle(ShowImageRequest request, CancellationToken cancellationToken)
    {
        Image image = await _imageRepo.GetByIdAsync(request.Id);

        if (image == null)
            return null;

        return _mapper.Map<ImageDto>(image);
    }
}
