using Microsoft.AspNetCore.Mvc;
using MusicStore.Web.Services;
using System;
using System.Linq;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public static string RockUrl = "https://youtu.be/Qyclqo_AV2M";
        private readonly IFileProvider _hostFileProvider;

        public HomeController(IFileProvider fileProvider)
        {
            _hostFileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return CreateRouteInfoContent();
        }


        public IActionResult Details(int id)
        {
            return CreateRouteInfoContent();
        }

        public IActionResult SearchMusic(string genre)
        {
            if (genre.ToUpper().Equals("ROCK"))
            {
                return RedirectPermanent(RockUrl);
            }
            if (genre.ToUpper().Equals("JAZZ"))
            {
                return RedirectToAction("Index");
            }
            if (genre.ToUpper().Equals("METAL"))
            {
                var randomId = new Random();

                return RedirectToAction("Details", new { id = randomId });
            }
            if (genre.ToUpper().Equals("CLASSIC"))
            {
                var pathToCssFile = @"wwwroot/css/site.css";
                var bytes = _hostFileProvider.GetBytes(pathToCssFile);
                var contentType = "text/css";
                var downloadName = "site.css";

                var fileContents = File(bytes, contentType, downloadName);

                return fileContents;
            }

            var message = ControllerContext.RouteData.Values.Values.Aggregate("", (current, value) => current + value);
            message += genre;

            return Content(message);
        }

        private ContentResult CreateRouteInfoContent()
        {
            var controllerName = ControllerContext.RouteData.Values["controller"];
            var actionName = ControllerContext.RouteData.Values["action"];
            var message = $"{controllerName}:{actionName}";

            var id = RouteData.Values["id"];
            if (id != null)
            {
                message += $":{id}";
            }

            var genreParam = RouteData.Values["genre"];
            if (genreParam != null)
            {
                message += $":{genreParam}";
            }

            return Content(message);
        }
    }
}
