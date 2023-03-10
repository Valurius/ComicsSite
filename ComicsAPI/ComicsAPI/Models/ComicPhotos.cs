using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsAPI.Models
{
    public class ComicPhotos
    {
        [Key]
        public int Id { get; set; }
        public string PhotoNames { get; set; } = null!;
        [ForeignKey("Comics")]
        public int ComicId { get; set; }
    }
}
