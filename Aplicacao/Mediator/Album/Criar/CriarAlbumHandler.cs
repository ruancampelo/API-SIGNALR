using Dominio.Interfaces;
using Dominio.Model;
using MediatR;

namespace Aplicacao.Mediator.Album.Criar
{
    public class CriarAlbumHandler : IRequestHandler<CriarAlbumRequest, CriarAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ITransacao _transacao;

        public CriarAlbumHandler(IAlbumRepository albumRepository, ITransacao transacao)
        {
            _albumRepository = albumRepository;
            _transacao = transacao;
        }

        public async  Task<CriarAlbumResponse> Handle(CriarAlbumRequest request, CancellationToken cancellationToken)
        {
            var model = new Dominio.Model.Album { Title = request.Name, ArtistId = request.ArtistId };

            try
            {
                _transacao.Begin();

                await _albumRepository.Create(model);

                _transacao.Commit();
            }
            catch (Exception)
            {
                _transacao.RollBack();
                throw;
            }

            return new CriarAlbumResponse(model.AlbumID, model.Title, model.AlbumID);
        }
    }
}
