using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands.Create;

public class CreateImageRequestHandler : IRequestHandler<CreateImageRequest, bool>
{
    private readonly IImageRepo _imageRepo;
    private readonly IPropertyRepo _propertyRepo;
    private readonly IMapper _mapper;

    public CreateImageRequestHandler(IImageRepo imageRepo, IPropertyRepo propertyRepo ,IMapper mapper)
    {
        _imageRepo = imageRepo;
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateImageRequest request, CancellationToken cancellationToken)
    {        
        if (await _propertyRepo.GetByIdAsync(request.NewImage.PropertyId) == null)
            return false;

        Image image = _mapper.Map<Image>(request.NewImage);

        await _imageRepo.AddNewAsync(image);
        
        return true;
    }
}
