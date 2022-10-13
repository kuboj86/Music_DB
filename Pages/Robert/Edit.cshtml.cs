using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDB.Data;
using MusicDB.Models;

namespace MusicDB.Pages.Robert
{
    public class EditModel : PageModel
    {
        private readonly MusicDB.Data.MusicDBContext _context;

        public EditModel(MusicDB.Data.MusicDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song =  await _context.Song.FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }
            Song = song;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(Song.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SongExists(int id)
        {
          return _context.Song.Any(e => e.Id == id);
        }
    }
}
