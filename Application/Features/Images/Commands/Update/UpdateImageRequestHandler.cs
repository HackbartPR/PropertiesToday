using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands.Update;

public class UpdateImageRequestHandler : IRequestHandler<UpdateImageRequest, bool>
{
    private readonly IImageRepo _imageRepo;
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public UpdateImageRequestHandler(IImageRepo imageRepo, IPropertyRepo propertyRepo, IMapper mapper)
    {
        _imageRepo = imageRepo;
        _mapper = mapper;
        _propertyRepo = propertyRepo;
    }

    public async Task<bool> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
    {
        if (await _propertyRepo.GetByIdAsync(request.UpdateImage.PropertyId) == null)
            return false;

        Image image = await _imageRepo.GetByAsync(request.UpdateImage.Id);

        if (image == null || image.Property == null)
            return false;

        _mapper.Map(request.UpdateImage, image);
        await _imageRepo.UpdateAsync(image);
        
        return true;
    }
}
