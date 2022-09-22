using System.Runtime.Intrinsics.X86;

namespace MusicDB.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Song
                    {
                        SongTitle = "I Want It That Way",
                        Artist = "Backstreet Boys",
                        Album = "Millenium",
                        Genre = "Pop",
                        SongLength = DateTime.Parse("3:33"),
                        ReleaseDate = DateTime.Parse("4-12-1999")
                    },

                    new Song
                    {
                        SongTitle = "It's Gonna Be Me",
                        Artist = "NSYNC",
                        Album = "No Strings Attached",
                        Genre = "Pop",
                        SongLength = DateTime.Parse("3:11"),
                        ReleaseDate = DateTime.Parse("2000-06-12")
                    },

                    new Song
                    {
                        SongTitle = "Oops!... I Did it Again",
                        Artist = "Britney Spears",
                        Album = "Oops!... I Did it Again",
                        Genre = "Dance-pop",
                        SongLength = DateTime.Parse("3:31"),
                        ReleaseDate = DateTime.Parse("04-11-2000")

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
