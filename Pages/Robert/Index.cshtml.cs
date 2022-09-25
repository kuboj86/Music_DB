using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicDB.Data;
using MusicDB.Models;

namespace MusicDB.Pages.Robert
{
    public class IndexModel : PageModel
    {
        private readonly MusicDBContext _context;

        public IndexModel(MusicDBContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Artists { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? ArtistName { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> artistQuery = from n in _context.Song
                                             orderby n.Artist
                                             select n.Artist;

            var songs = from s in _context.Song select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.SongTitle.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ArtistName))
            {
                songs = songs.Where(s => s.Artist == ArtistName);
            }
            Artists = new SelectList(await artistQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
}
