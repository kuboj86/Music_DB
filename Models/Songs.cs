using System.ComponentModel.DataAnnotations;
namespace MusicDB.Models
{
    public class Songs
    {
        public int Id { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string? Genre { get; set; }
        public string? RecordLabel { get; set; }
        public int? SongLength { get; set; }
        public DateTime? ReleaseDate { get; set; }  
    }
}
