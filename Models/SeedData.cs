using Microsoft.EntityFrameworkCore;
using MusicDB.Data;

namespace MusicDB.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MusicDBContext>>()))
            {
                if (context == null || context.Song == null)
                {
                    throw new ArgumentNullException("Null RazorPagesSongContext");
                }

                // Look for any Songs.
                if (context.Song.Any())
                {
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new Song
                    {
                        SongTitle = "I Want It That Way",
                        Artist = "Backstreet Boys",
                        Album = "Millenium",
                        Genre = "Pop",
                        SongLength = "3:33",
                        ReleaseDate = DateTime.Parse("4-12-1999")
                    },
                    new Song
                    {
                        SongTitle = "It's Gonna Be Me",
                        Artist = "NSYNC",
                        Album = "No Strings Attached",
                        Genre = "Pop",
                        SongLength = "3:11",
                        ReleaseDate = DateTime.Parse("2000-06-12")
                    },
                    new Song
                    {
                        SongTitle = "Oops!... I Did it Again",
                        Artist = "Britney Spears",
                        Album = "Oops!... I Did it Again",
                        Genre = "Dance-pop",
                        SongLength = "3:31",
                        ReleaseDate = DateTime.Parse("04-11-2000")

                    },
                    new Song
                    {
                        SongTitle = "Beautiful",
                        Artist = "Christina Aguilera",
                        Album = "Stripped",
                        Genre = "Pop",
                        SongLength = "4:00",
                        ReleaseDate = DateTime.Parse("11-16-2002")

                    },
                    new Song
                    {
                        SongTitle = "It's Gonna Be Me",
                        Artist = "NSYNC",
                        Album = "No Strings Attached",
                        Genre = "Pop",
                        SongLength = "3:11",
                        ReleaseDate = DateTime.Parse("2000-06-12")
                    },
                    new Song
                    {
                        SongTitle = "Hollaback Girl",
                        Artist = "Gwen Stefani",
                        Album = "Love.Angel.Music.Baby",
                        Genre = "Hip Hop",
                        SongLength = "3:19",
                        ReleaseDate = DateTime.Parse("03-22-2005")

                    },
                    new Song
                    {
                        SongTitle = "Stan",
                        Artist = "Eminem",
                        Album = "The Marshall Mathers LP",
                        Genre = "Horrorcore",
                        SongLength = "6:44",
                        ReleaseDate = DateTime.Parse("11-05-2000")

                    },
                    new Song
                    {
                        SongTitle = "Hey Ya!",
                        Artist = "Outkast",
                        Album = "Speakerboxxx/The Love Below",
                        Genre = "Hip hop",
                        SongLength = "3:55",
                        ReleaseDate = DateTime.Parse("08-25-2003")
                    },
                    new Song
                    {
                        SongTitle = "Toxic",
                        Artist = "Britney Spears",
                        Album = "In the Zone",
                        Genre = "Dance-Pop",
                        SongLength = "3:19",
                        ReleaseDate = DateTime.Parse("01-13-2004")
                    },
                    new Song
                    {
                        SongTitle = "Seven Nation Army",
                        Artist = "The White Stripes",
                        Album = "Elephant",
                        Genre = "Alternative Rock",
                        SongLength = "3:52",
                        ReleaseDate = DateTime.Parse("02-17-2003")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
