using Dominio.Model;

namespace Dominio.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetAlbum();
        Task<Album> GetById(int id);
        Task Create(Album album);
        Task Update(Album album);
        Task Delete(Album album);
    }
}
