using Application.Features.Properties.Commands.Create;
using Application.Features.Properties.Commands.Update;
using Application.Features.Properties.Queries.Show;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly ISender _mediatrSender;

    public PropertiesController(ISender mediatrSender)
    {
        _mediatrSender = mediatrSender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddNewProperty([FromBody] NewProperty newPropertyRequest)
    {
        bool isSuccessful = await _mediatrSender.Send(new CreatePropertyRequest(newPropertyRequest));

        if (!isSuccessful)
        {
            return BadRequest("Falha ao realizar cadastro");
        }

        return Ok("Cadastrado com sucesso");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProperty([FromBody] UpdateProperty updateProperty)
    {
        bool isSuccessful = await _mediatrSender.Send(new UpdatePropertyRequest(updateProperty));

        if (!isSuccessful)
        {
            return NotFound();
        }

        return Ok("Atualizado com sucesso");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ShowProperty(int id)
    {
        PropertyDto property = await _mediatrSender.Send(new ShowPropertyRequest(id));

        if (property == null)
        {
            return NotFound();
        }

        return Ok(property);
    }

}
