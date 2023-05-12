using Microsoft.AspNetCore.Mvc;
using PigApp.Models;
using static PigApp.Models.SessionExtentions;

namespace PigApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            // Notify if there is a winner
            if (game.IsGameOver)
            {
                TempData["message"] = $"{game.CurrentPlayerName} wins!";
            }

            // Pass game object to the view
            return View(game);
        }

        [HttpPost]
        public IActionResult NewGame()
        {
            // Get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.NewGame();

            // Store game object in session and do a PRG pattern redirect
            sess.SetGame(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Roll()
        {
            // Get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.Roll();

            // Store game object in session and do a PRG pattern redirect
            sess.SetGame(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Hold()
        {
            // Get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.Hold();

            // Store game object in session and do a PRG pattern redirect
            sess.SetGame(game);
            return RedirectToAction("Index");
        }
    }
}