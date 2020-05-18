using System.Collections.Generic;
using MusicStoreCore.Data.DomainClasses;
using MusicStoreCore.Data.Interfaces;

namespace MusicStoreCore.Data.Repositories
{
    public class GenreDummyRepository : IGenreRepository
    {
        private static List<Genre> _genres = new List<Genre> {
            new Genre
            {
                Id = 1,
                Name = "Metal"
            },
            new Genre
            {
                Id = 2,
                Name = "Pop"
            },
            new Genre
            {
                Id = 3,
                Name = "Jazz"
            }
        };

        public IReadOnlyList<Genre> GetAll()
        {
            return _genres;
        }
    }
}