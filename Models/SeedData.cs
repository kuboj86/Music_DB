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

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
