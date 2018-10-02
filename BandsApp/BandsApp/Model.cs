using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BandsApp
{
    public class BandsContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.BandsApp;Trusted_Connection=True;");
        }
    }

    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }

        public List<Album> Albums { get; set; }
    }

    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public int BandId { get; set; }
        public Band Band { get; set; }
    }
}