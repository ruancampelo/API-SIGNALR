using Dominio.Interfaces;
using MediatR;

namespace Aplicacao.Mediator.Album.Alterar
{
    public class AlterarAlbumHandler : IRequestHandler<AlterarAlbumRequest, AlterarAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ITransacao _transacao;


        public AlterarAlbumHandler(IAlbumRepository albumRepository, ITransacao transacao)
        {
            _albumRepository = albumRepository;
            _transacao = transacao;
        }

        public async Task<AlterarAlbumResponse> Handle(AlterarAlbumRequest request, CancellationToken cancellationToken)
        {
            var result = await _albumRepository.GetById(request.Id);

            if (result == null)
            {
                return new AlterarAlbumResponse();
            }

            try
            {
                _transacao.Begin();

                result.Title = request.Name;
                await _albumRepository.Update(result);

                _transacao.Commit();

            }
            catch (Exception ex)
            {
                _transacao.RollBack();
                throw;
            }

            return new AlterarAlbumResponse { Name = request.Name };
        }
    }
}
