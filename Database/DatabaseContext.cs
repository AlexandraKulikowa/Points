using Microsoft.EntityFrameworkCore;
using Points.Models;

namespace Points.Database
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
            modelBuilder.Entity<Point>().HasData(
                new Point
                {
                    PointId = 1,
                    X = 250,
                    Y = 200,
                    Radius = 7,
                    Color = "Lightgrey"
                },
                new Point
                {
                    PointId = 2,
                    X = 450,
                    Y = 200,
                    Radius = 14,
                    Color = "Red"
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Text = "comment 1",
                    BackgroundColor = "White",
                    PointId = 1
                },
                new Comment
                {
                    Id = 2,
                    Text = "comment 2",
                    BackgroundColor = "Yellow",
                    PointId = 1
                },
                new Comment
                {
                    Id = 3,
                    Text = "comment 3",
                    BackgroundColor = "White",
                    PointId = 2
                },
                new Comment
                {
                    Id = 4,
                    Text = "comment 4",
                    BackgroundColor = "Grey",
                    PointId = 2
                },
                new Comment
                {
                    Id = 5,
                    Text = "comment 5",
                    BackgroundColor = "White",
                    PointId = 2
                },
                new Comment
                {
                    Id = 6,
                    Text = "comment 6 looooooooooooong comment",
                    BackgroundColor = "Yellow",
                    PointId = 2
                },
                new Comment
                {
                    Id = 7,
                    Text = "comment 7",
                    BackgroundColor = "Grey",
                    PointId = 2
                },
                new Comment
                {
                    Id = 8,
                    Text = "comment 8",
                    BackgroundColor = "White",
                    PointId = 2
                }
            );
        }

    }
}