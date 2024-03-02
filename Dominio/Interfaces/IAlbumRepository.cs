using Dominio.Model;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbum();
        Task<Album> GetById(int id);
        Task Create(Album album);
        Task Update(Album album);
        Task Delete(Album album);
    }
}
