using Microsoft.EntityFrameworkCore;
using Points.Models;

namespace Points
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Point> Points { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>()
                .HasData(
                    new Point[]
                    {
                        new Point { Id = 1, X = 100, Y = 400, Radius = 20, Color = Color.Grey },
                        new Point { Id = 2, X = 300, Y = 400, Radius = 35, Color = Color.Red }
                    });


            modelBuilder.Entity<Comment>()
                .HasData(new
                {
                    Id = 1,
                    Text = "comment 1",
                    BackgroundColor = Color.White,
                    PointId = 1
                },
                new
                {
                    Id = 2,
                    Text = "comment 2",
                    BackgroundColor = Color.Yellow,
                    PointId = 1
                },
                new
                {
                    Id = 3,
                    Text = "comment 3",
                    BackgroundColor = Color.White,
                    PointId = 2
                },
                new
                {
                    Id = 4,
                    Text = "comment 4",
                    BackgroundColor = Color.Grey,
                    PointId = 2
                },
                new
                {
                    Id = 5,
                    Text = "comment 5",
                    BackgroundColor = Color.White,
                    PointId = 2
                },
                new
                {
                    Id = 6,
                    Text = "comment 6 looooooooooooong comment",
                    BackgroundColor = Color.Yellow,
                    PointId = 2
                },
                new
                {
                    Id = 7,
                    Text = "comment 7",
                    BackgroundColor = Color.Grey,
                    PointId = 2
                },
                new
                {
                    Id = 8,
                    Text = "comment 8",
                    BackgroundColor = Color.White,
                    PointId = 2
                });
        }
    }
}