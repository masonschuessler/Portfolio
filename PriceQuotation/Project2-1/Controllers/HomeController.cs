using Microsoft.AspNetCore.Mvc;
using Project2_1.Models;

namespace Project2_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Discount = 0;
            ViewBag.Total = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(PriceQuotation quote)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Discount = quote.CalculateDiscount();
                ViewBag.Total = quote.CalculateTotal();
            }
            else
            {
                ViewBag.Discount = 0;
                ViewBag.Total = 0;
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}