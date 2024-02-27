using MediatR;

namespace Aplicacao.Mediator.Album.Excluir
{
    public record ExcluirAlbumRequest(int AlbumId) : IRequest<string>;
    
}
