using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands.Create;

public class CreatePropertyRequest : IRequest<bool>
{
    public NewProperty PropertyRequest { get; set; }

    public CreatePropertyRequest(NewProperty newPropertyRequest)
    {
        PropertyRequest = newPropertyRequest;
    }
}
