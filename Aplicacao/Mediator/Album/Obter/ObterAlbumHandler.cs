using Dominio.Interfaces;
using MediatR;

namespace Aplicacao.Mediator.Album.Obter
{
    public class ObterAlbumHandler : IRequestHandler<ObterAlbumRequest, IEnumerable<ObterAlbumResponse>>
    {
        private readonly IAlbumRepository _albumRepository;

        public ObterAlbumHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<ObterAlbumResponse>> Handle(ObterAlbumRequest request, CancellationToken cancellationToken)
        {
            var result = await _albumRepository.GetAlbum();
            if (result is null)
                return null;

            var resultList = new List<ObterAlbumResponse>();

            foreach (var album in result)
            {
                var albumResponse = new ObterAlbumResponse();
                albumResponse.Title = album.Title;
                albumResponse.AlbumId = album.AlbumID;
                albumResponse.ArtistName = album.Artist.Name;
                resultList.Add(albumResponse);
            }

            return resultList;
        }
    }
}