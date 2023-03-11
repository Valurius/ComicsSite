using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ComicsAPI.Models
{
    public class Comic
    {
        [Key]
        public int ComicId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PreviewPhotoName { get; set; } = null!;
        public virtual List<ComicPhoto>? ComicPhotos { get; set; }
    }
}
