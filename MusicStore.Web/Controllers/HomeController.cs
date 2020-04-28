using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
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
            throw new NotImplementedException();
        }
    }
}
