using System.Collections.Generic;
using MusicStoreCore.Data.DomainClasses;
using MusicStoreCore.Data.Interfaces;

namespace MusicStoreCore.Data.Repositories
{
    public class GenreRepository :IGenreRepository
    {
        public IList<Genre> GetAll()
        {
            IList<Genre> genres = new List<Genre>();
            var jazz = new Genre
            {
                Id = 1,
                Name = "jazz"
            };
            genres.Add(jazz);

            var rock = new Genre
            {
                Id = 2,
                Name = "rock"
            };
            genres.Add(rock);
            var metal = new Genre
            {
                Id = 3,
                Name = "metal"
            };
            genres.Add(metal);

            var classic = new Genre
            {
                Id = 4,
                Name = "classic"
            };
            genres.Add(classic);

            return genres;
        }
    }
}