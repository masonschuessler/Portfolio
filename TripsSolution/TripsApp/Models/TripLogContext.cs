using Microsoft.EntityFrameworkCore;

namespace TripsApp.Models
{
    public class TripLogContext : DbContext
    {
        public TripLogContext(DbContextOptions<TripLogContext> options)
            : base(options) { }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Denver",
                    StartDate = new DateTime(2023, 6, 6, 15, 0, 0, 0),
                    EndDate = new DateTime(2023, 6, 14, 11, 0, 0, 0),
                    Accommodation = "",
                    AccommodationPhone = "",
                    AccommodationEmail = "",
                    ThingToDo1 = "Sight-see",
                    ThingToDo2 = "",
                    ThingToDo3 = ""
                },
                new Trip
                {
                    TripId = 2,
                    Destination = "Texas",
                    StartDate = new DateTime(2024, 1, 1, 15, 0, 0, 0),
                    EndDate = new DateTime(2024, 1, 7, 11, 0, 0, 0),
                    Accommodation = "Girlfriends' family",
                    AccommodationPhone = "503-555-1234",
                    AccommodationEmail = "",
                    ThingToDo1 = "Vist inlaws",
                    ThingToDo2 = "East BBQ",
                    ThingToDo3 = "Drink Korean Wine"
                }
            );
        }
    }
}