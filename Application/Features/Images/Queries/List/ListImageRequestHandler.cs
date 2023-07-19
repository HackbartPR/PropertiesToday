using Application.Models.Image;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries.List;

public class ListImageRequestHandler : IRequestHandler<ListImageRequest, List<ImageDto>>
{
    private readonly IImageRepo _imageRepo;
    private readonly IMapper _mapper;

    public ListImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
    {
        _imageRepo = imageRepo;
        _mapper = mapper;
    }

    public async Task<List<ImageDto>> Handle(ListImageRequest request, CancellationToken cancellationToken)
    {
        List<Image> listImages = await _imageRepo.GetAllAsync();

        return _mapper.Map<List<ImageDto>>(listImages);
    }
}
