﻿using Application.Models;
using MediatR;

namespace Application.Features.Properties.Queries.Show;

public class ShowPropertyRequest : IRequest<ShowProperty>
{
    public int Id { get; set; }

    public ShowPropertyRequest(int id)
    {
        Id = id;
    }
}
