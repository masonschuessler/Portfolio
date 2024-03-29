﻿using Microsoft.AspNetCore.Mvc;
using TripsApp.Models;

namespace TripsApp.Controllers
{
    public class TripController : Controller
    {
        private TripLogContext context { get; set; }
        public TripController(TripLogContext ctx) => context = ctx;

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add(string id = "")
        {
            var vm = new TripViewModel();

            /********************************************************************************************
            * need to pass Accommodation value, or Destination value (depending on page number and 
            * Accommodation value), to by view. 
            * 
            * Accommodation is an optional value - don't need it to persist after being read if it's null.
            * So, do straight read, and if it's not null, use Keep() method to make sure it persists.
            * 
            * Destination is a a required value - always need it to persist after being read. 
            * So, use Peek() method to read it and make sure it persists.
            *********************************************************************************************/

            if (id.ToLower() == "page2")
            {
                var accommodation = TempData[nameof(Trip.Accommodation)]?.ToString();

                if (string.IsNullOrEmpty(accommodation))
                {  // skip to page 3
                    vm.PageNumber = 3;
                    var destination = TempData.Peek(nameof(Trip.Destination)).ToString();
                    vm.Trip = new Trip { Destination = destination };
                    return View("Add3", vm);
                }
                else
                {
                    vm.PageNumber = 2;
                    vm.Trip = new Trip { Accommodation = accommodation };
                    TempData.Keep(nameof(Trip.Accommodation));
                    return View("Add2", vm);
                }
            }
            else if (id.ToLower() == "page3")
            {
                vm.PageNumber = 3;
                vm.Trip = new Trip { Destination = TempData.Peek(nameof(Trip.Destination)).ToString() };

                return View("Add3", vm);
            }
            else
            {
                vm.PageNumber = 1;
                return View("Add1", vm);
            }
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.PageNumber == 1)
            {
                if (ModelState.IsValid) // only page 1 has required data
                {
                    /***************************************************
                    * Store data in TempData and redirect (PRG pattern)
                    ****************************************************/
                    TempData[nameof(Trip.Destination)] = vm.Trip.Destination;
                    TempData[nameof(Trip.Accommodation)] = vm.Trip.Accommodation;
                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
                    return RedirectToAction("Add", new { id = "Page2" });
                }
                else
                {
                    return View("Add1", vm);
                }
            }
            else if (vm.PageNumber == 2)
            {
                /***************************************************
                    * Store data in TempData and redirect (PRG pattern)
                ****************************************************/
                TempData[nameof(Trip.AccommodationPhone)] = vm.Trip.AccommodationPhone;
                TempData[nameof(Trip.AccommodationEmail)] = vm.Trip.AccommodationEmail;
                return RedirectToAction("Add", new { id = "Page3" });
            }
            else if (vm.PageNumber == 3)
            {
                /***************************************************
                    * Don't need data in TempData to persist after 
                    * updating database, so do straight read.
                ****************************************************/
                vm.Trip.Destination = TempData[nameof(Trip.Destination)].ToString();
                vm.Trip.Accommodation = TempData[nameof(Trip.Accommodation)]?.ToString();
                vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)];
                vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)];
                vm.Trip.AccommodationPhone = TempData[nameof(Trip.AccommodationPhone)]?.ToString();
                vm.Trip.AccommodationEmail = TempData[nameof(Trip.AccommodationEmail)]?.ToString();

                context.Trips.Add(vm.Trip);
                context.SaveChanges();
                TempData["message"] = $"Trip to {vm.Trip.Destination} added.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}