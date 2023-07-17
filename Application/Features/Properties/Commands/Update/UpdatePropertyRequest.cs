using Application.Models;
using MediatR;

namespace Application.Features.Properties.Commands.Update;

public class UpdatePropertyRequest : IRequest<bool>
{
    public UpdateProperty UpdateProperty { get; set; }

    public UpdatePropertyRequest(UpdateProperty updateProperty)
    {
        this.UpdateProperty = updateProperty;
    }
}
