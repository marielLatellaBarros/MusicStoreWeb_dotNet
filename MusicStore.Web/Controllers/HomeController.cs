using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index()
        {
            var message = ControllerContext.RouteData.Values.Values.Aggregate("", (current, value) => current + value);

            return Content(message);
        }

    }
}
