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

        public IList<Song> Song { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Song != null)
            {
                Song = await _context.Song.ToListAsync();
            }
        }
    }
}
