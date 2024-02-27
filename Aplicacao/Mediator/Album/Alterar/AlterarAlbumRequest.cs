using MediatR;

namespace Aplicacao.Mediator.Album.Alterar
{
    public class AlterarAlbumRequest : IRequest<AlterarAlbumResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AlterarAlbumRequest(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
