using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Model
{
    [Table("Album")]
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set;}
    }
}
