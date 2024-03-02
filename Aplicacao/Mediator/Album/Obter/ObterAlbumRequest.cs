using MediatR;

namespace Aplicacao.Mediator.Album.Obter
{
    public class ObterAlbumRequest : IRequest<IEnumerable<ObterAlbumResponse>>
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
    }
}
