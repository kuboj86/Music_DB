using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicDB.Data;
using MusicDB.Models;

namespace MusicDB.Pages.Robert
{
    public class DeleteModel : PageModel
    {
        private readonly MusicDB.Data.MusicDBContext _context;

        public DeleteModel(MusicDB.Data.MusicDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FirstOrDefaultAsync(m => m.Id == id);

            if (song == null)
            {
                return NotFound();
            }
            else 
            {
                Song = song;
            }

            var limit = 10;
            for (int i = 1; i < limit; i++)
            {
                var nextSong = await _context.Song.FirstOrDefaultAsync(m => m.Id == id + i);
                if (nextSong != null)
                {
                    ViewData["nextId"] = nextSong.Id;
                    break;
                }
                if (i == limit - 1 && nextSong == null)
                {
                    ViewData["nextId"] = id;
                }
            }

            for (int i = 1; i < limit; i++)
            {
                if (id - 1 == 0)
                {
                    ViewData["prevId"] = 1;
                    break;
                }
                var prevSong = await _context.Song.FirstOrDefaultAsync(m => m.Id == id - i);
                if (prevSong != null)
                {
                    ViewData["prevId"] = prevSong.Id;
                    break;
                }
                if (i == limit - 1 && prevSong == null)
                {
                    ViewData["prevId"] = id;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }
            var song = await _context.Song.FindAsync(id);

            if (song != null)
            {
                Song = song;
                _context.Song.Remove(Song);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
