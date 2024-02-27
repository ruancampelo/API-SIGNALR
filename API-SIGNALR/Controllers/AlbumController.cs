using Aplicacao.Mediator.Album.Alterar;
using Aplicacao.Mediator.Album.Criar;
using Aplicacao.Mediator.Album.Excluir;
using Aplicacao.Mediator.Album.Obter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API_SIGNALR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Album")]
        public async Task<IActionResult> Obter()
        {
            var resultado = await _mediator.Send(new ObterAlbumRequest());

            if (resultado is null) 
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> AtualizarAsync([FromBody] AlterarAlbumRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Created("Alterado com Sucesso", resultado);
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> CriarAsync([FromBody] CriarAlbumRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Created("Criado com Sucesso", resultado);
        }

        [HttpDelete]
        [Route("Excluir")]
        public async Task<IActionResult> ExcluirAsync([FromBody] ExcluirAlbumRequest request)
        {
            var resultado = await _mediator.Send(request);

            if(resultado is null)
                return NotFound();

            return NoContent();
        }

    }
}
