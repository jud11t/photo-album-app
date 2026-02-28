using System.ComponentModel.DataAnnotations;
using PhotoAlbumApp.Data;

namespace PhotoAlbumApp.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public DateTime UploadDate { get; set; }

        public string FilePath { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}