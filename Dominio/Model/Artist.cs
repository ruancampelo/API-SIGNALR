using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Model
{
    [Table("Artist")]
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public List<Album> Albums { get; set;}
    }
}
