using Microsoft.AspNetCore.Mvc;
using MusicStore.Data.Interfaces;

namespace MusicStore.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAlbumRepository _albumRepository;
        public StoreController(IGenreRepository genreRepository, IAlbumRepository albumRepository)
        {
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
        }

        public IActionResult Index()
        {
            var genres = _genreRepository.GetAll();

            return View(genres);
        }

        public IActionResult Browse(int id)
        {
            var albumsForGenre = _albumRepository.GetByGenre(id);
            if (albumsForGenre != null)
            {
                return View(albumsForGenre);
            }

            return NotFound();
        }

        public IActionResult Details(int id)
        {
            var albumDetails = _albumRepository.GetById(id);
            if (albumDetails != null)
            {
                return View(albumDetails);
            }

            return NotFound();
        }
    }
}