using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public static string RockUrl = "https://youtu.be/Qyclqo_AV2M";
        public IActionResult Index()
        {
            var message = ControllerContext.RouteData.Values.Values.Aggregate("", (current, value) => current + value);

            return Content(message);
        }

        public IActionResult About()
        {
            var message = ControllerContext.RouteData.Values.Values.Aggregate("", (current, value) => current + value);

            return Content(message);
        }

        public IActionResult Details(int id)
        {
            var message = ControllerContext.RouteData.Values.Values.Aggregate("", (current, value) => current + value);
            message += id;

            return Content(message);
        }

        public IActionResult SearchMusic(string genre)
        {
            if (genre.ToUpper().Equals("ROCK")) 
            {
                return RedirectPermanent(RockUrl);
            } 
            else if (genre.ToUpper().Equals("JAZZ"))
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
