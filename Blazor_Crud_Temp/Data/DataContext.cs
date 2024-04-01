using Blazor_Crud_Temp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Crud_Temp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { _id = 1, Title = "The Legend of Zelda: Breath of The Wild", Publisher = "Nintendo", ReleaseYear = 2017 },
                new VideoGame { _id = 2, Title = "The Witcher 3: Wild Hunt", Publisher = "CD Projekt", ReleaseYear = 2015},
                new VideoGame { _id = 3, Title = "Persona 5 Royal", Publisher = "Sega", ReleaseYear = 2019}
            );
        }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
