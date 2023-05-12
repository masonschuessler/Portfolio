using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TripsApp.Models;

namespace TripsApp.Controllers
{
    public class HomeController : Controller
    {
        private TripLogContext context { get; set; }

        public HomeController(TripLogContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index()
        {
            var trips = context.Trips.OrderBy(t => t.StartDate).ToList();
            return View(trips);
        }
    }
}