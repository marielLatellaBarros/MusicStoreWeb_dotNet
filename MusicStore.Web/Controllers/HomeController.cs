using Microsoft.AspNetCore.Mvc;
using System;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }

    }
}
