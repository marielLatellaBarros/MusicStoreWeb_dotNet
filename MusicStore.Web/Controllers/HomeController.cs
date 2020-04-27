using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
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

    }
}
