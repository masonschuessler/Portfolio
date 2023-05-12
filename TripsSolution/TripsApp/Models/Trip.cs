using System;
using System.ComponentModel.DataAnnotations;

namespace TripsApp.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required(ErrorMessage = "You Must Enter a Destination")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "You Must Enter a Start Date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "You Must Enter an End Date")]
        public DateTime? EndDate { get; set; }

        public string? Accommodation { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }

        public string? ThingToDo1 { get; set; }
        public string? ThingToDo2 { get; set; }
        public string? ThingToDo3 { get; set; }

    }
}