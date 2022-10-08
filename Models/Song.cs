using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MusicDB.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }

        [StringLength(30)]
        public string Artist { get; set; }

        [StringLength(30)]
        public string Album { get; set; }

        [StringLength(30)]
        public string? Genre { get; set; }

        //[DataType(DataType.Time)]
        [RegularExpression(@"^[0-5]?\d:[0-5]\d$", ErrorMessage = "Length must be formatted as 12:34")]
        [Display(Name = "Song Length")]
        public string? SongLength { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; } 
     }
}
