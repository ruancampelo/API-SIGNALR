using Dominio.Interfaces;
using MediatR;

namespace Aplicacao.Mediator.Album.Excluir
{
    public class ExcluirAlbumHandler : IRequestHandler<ExcluirAlbumRequest, string>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ITransacao _transacao;

        public ExcluirAlbumHandler(IAlbumRepository albumRepository, ITransacao transacao)
        {
            _albumRepository = albumRepository;
            _transacao = transacao;
        }

        public async Task<string> Handle(ExcluirAlbumRequest request, CancellationToken cancellationToken)
        {
            var resultado = await _albumRepository.GetById(request.AlbumId);

            if (resultado is null)
                return null;

            try
            {
                _transacao.Begin();

                await _albumRepository.Delete(resultado);

                _transacao.Commit();
            }
            catch (Exception)
            {
                _transacao.RollBack();
                throw;
            }

            return resultado.Title;
        }
    }
}
