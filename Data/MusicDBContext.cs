using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicDB.Models;

namespace MusicDB.Data
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext (DbContextOptions<MusicDBContext> options)
            : base(options)
        {
        }

        public DbSet<MusicDB.Models.Song> Song { get; set; } = default!;
    }
}
