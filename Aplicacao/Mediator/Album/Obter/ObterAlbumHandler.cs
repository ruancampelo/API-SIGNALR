using Dominio.Interfaces;
using MediatR;

namespace Aplicacao.Mediator.Album.Obter
{
    public class ObterAlbumHandler : IRequestHandler<ObterAlbumRequest, ObterAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;

        public ObterAlbumHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<ObterAlbumResponse> Handle(ObterAlbumRequest request, CancellationToken cancellationToken)
        {
            var result = await _albumRepository.GetAlbum();
            if (result is null)
                return null;

            return new ObterAlbumResponse
            {
                AlbumId = result.AlbumID,
                Title = result.Title,
            };
        }
    }
}