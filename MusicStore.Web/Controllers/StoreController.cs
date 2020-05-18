using Microsoft.AspNetCore.Mvc;
using MusicStoreCore.Data.Interfaces;
using MusicStoreCore.Data.Repositories;

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
            return View(_genreRepository.GetAll());
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
    }
}