using MediatR;

namespace Aplicacao.Mediator.Album.Criar
{
    public class CriarAlbumRequest : IRequest<CriarAlbumResponse>
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }

    }
}
