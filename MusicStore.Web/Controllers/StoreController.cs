using Microsoft.AspNetCore.Mvc;
using MusicStoreCore.Data.Interfaces;

namespace MusicStore.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        public StoreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            return View(_genreRepository.GetAll());
        }
    }
}