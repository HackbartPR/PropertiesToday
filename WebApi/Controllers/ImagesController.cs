using Application.Features.Images.Commands.Create;
using Application.Models.Image;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly ISender _mediatrSender;

    public ImagesController(ISender sender)
    {
        _mediatrSender = sender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddNewImage([FromBody] NewImage newImage)
    {
        bool isSuccessful = await _mediatrSender.Send(new CreateImageRequest(newImage));

        if (!isSuccessful)
        {
            return BadRequest("Falha ao realizar cadastro");
        }

        return Ok("Cadastrado com sucesso");
    }
}
