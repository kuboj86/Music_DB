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
        private readonly MusicDBContext _context;

        public IndexModel(MusicDBContext context)
        {
            _context = context;
        }
        public string SongTitleSort { get; set; }
        public string ArtistNameSort { get; set; }
        public string AlbumNameSort { get; set; }
        public string GenreSort { get; set; }
        public bool isTitleFiltered { get; set; }
        public bool isArtistFiltered { get; set; }
        public bool isAlbumFiltered { get; set; }

        public bool isGenreFiltered { get; set; }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public IList<Song> Songs { get; set; } = default!;

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
            IQueryable<Song> Song = from s in _context.Song
                                    select s;

            var songs = from s in _context.Song select s;
            //SearchString = SearchString;

            // using System;
            SongTitleSort = String.IsNullOrEmpty(sort) ? "songTitle" : "";
            ArtistNameSort = String.IsNullOrEmpty(sort) ? "artistName" : "";
            AlbumNameSort = String.IsNullOrEmpty(sort) ? "albumName" : "";
            GenreSort = String.IsNullOrEmpty(sort) ? "genreName" : "";

            switch (sort)
            {
                case "songTitle":
                    if(isTitleFiltered == false)
                    {
                        SetToFalse();
                        Song = Song.OrderBy(s => s.SongTitle);
                        isTitleFiltered = true;
                    }
                    else
                    {
                        Song = Song.OrderByDescending(s => s.SongTitle);
                        isTitleFiltered = false;
                    }
                    break;

                case "artistName":
                    if (isArtistFiltered == false)
                    {
                        SetToFalse();
                        Song = Song.OrderBy(s => s.Artist);
                        isArtistFiltered = true;
                    }
                    else
                    {
                        Song = Song.OrderByDescending(s => s.Artist);
                        isArtistFiltered = false;
                    }
                    break;
                case "albumName":
                    if (isAlbumFiltered == false)
                    {
                        SetToFalse();
                        Song = Song.OrderBy(s => s.Album);
                        isAlbumFiltered = true;
                    }
                    else
                    {
                        Song = Song.OrderByDescending(s => s.Album);
                        isAlbumFiltered = false;
                    }
                    break;
                case "genreName":
                    if (isGenreFiltered == false)
                    {
                        SetToFalse();
                        Song = Song.OrderBy(s => s.Genre);
                        isGenreFiltered = true;
                    }
                    else
                    {
                        Song = Song.OrderByDescending(s => s.Genre);
                        isGenreFiltered = false;
                    }
                    break;
                default:
                    break;
            }

            if (!String.IsNullOrWhiteSpace(SearchString))
            {
                Song = Song.Where(s => s.SongTitle.Contains(SearchString)
                                       || s.Artist.Contains(SearchString)
                                       || s.Genre.Contains(SearchString)
                                       || s.Album.Contains(SearchString));
            }

            Songs = await Song.AsNoTracking().ToListAsync();
        }
        public void SetToFalse()
        {
            isTitleFiltered = false;
            isAlbumFiltered = false;
            isArtistFiltered = false;
            isGenreFiltered = false;
        }

    }
}
