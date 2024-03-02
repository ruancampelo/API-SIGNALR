using Dominio.Interfaces;
using Dominio.Model;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly Contexto _contexto;
        public AlbumRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Album>> GetAlbum()
        {
            var result = _contexto.Set<Album>().Include(x => x.Artist).AsEnumerable();

            return result;
        }

        public async Task<Album> GetById(int id)
        {
            var result = _contexto.Set<Album>().FirstOrDefault(x => x.AlbumID == id);

            return result;
        }

        public async Task Create(Album album)
        {
            
            _contexto.Albums.Add(album);
            _contexto.SaveChanges();
        }

        public async Task Update(Album album)
        {
            _contexto.Albums.Update(album);
            _contexto.SaveChanges();
        }

        public async Task Delete(Album album)
        {
            _contexto.Albums.Remove(album);
            _contexto.SaveChanges();
        }

    }
}
