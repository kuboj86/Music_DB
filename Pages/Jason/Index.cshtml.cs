using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicDB.Data;
using MusicDB.Models;

namespace MusicDB.Pages.Jason
{
    public class IndexModel : PageModel
    {
        private readonly MusicDB.Data.MusicDBContext _context;

        public IndexModel(MusicDB.Data.MusicDBContext context)
        {
            _context = context;
        }
        public string SongTitleSort { get; set; }
        public int ArtistNameSort { get; set; }
        public int AlbumNameSort { get; set; }
        public int GenreSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public IList<Song> Songs { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    var songs = from s in _context.Song select s;

        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        songs = songs.Where(s => s.SongTitle.Contains(SearchString));
        //    }
        //    Songs = await songs.ToListAsync();
        //}
        public async Task OnGetAsync(string sort)
        {
            var songs = from s in _context.Song select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.SongTitle.Contains(SearchString));
            }
            Songs = await songs.ToListAsync();

            // using System;
            SongTitleSort = String.IsNullOrEmpty(sort) ? "song_title" : "";
            //DateSort = sort == "Date" ? "date_desc" : "Date";

            IQueryable<Song> Song = from s in _context.Song
                                    select s;

            switch (sort)
            {
                case "song_title":
                    Song = Song.OrderByDescending(s => s.SongTitle);
                    break;
                //case "Date":
                //    Song = Song.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    Song = Song.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    //Song = Song.OrderBy(s => s.LastName);
                    break;
            }

            Songs = await Song.AsNoTracking().ToListAsync();
        }
    }
}
