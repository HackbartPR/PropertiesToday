using Application.Features.Images.Commands.Create;
using Application.Features.Images.Commands.Delete;
using Application.Features.Images.Commands.Update;
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

    [HttpPut("update")]
    public async Task<IActionResult> UpdateImage([FromBody] UpdateImage updateImage)
    {
        bool isSuccessful = await _mediatrSender.Send(new UpdateImageRequest(updateImage));

        if (!isSuccessful)
            return BadRequest("Imagem não encontrada");

        return Ok("Atualizado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        bool isDeleted = await _mediatrSender.Send(new DeleteImageRequest(id));

        if (!isDeleted)
            return BadRequest("Imagem não pode ser deletada");

        return Ok("Deletado com sucesso");
    }
}
