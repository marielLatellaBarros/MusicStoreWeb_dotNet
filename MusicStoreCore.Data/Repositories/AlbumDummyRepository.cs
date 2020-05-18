using MusicStoreCore.Data.DomainClasses;
using System.Collections.Generic;
using System.Linq;
using MusicStoreCore.Data.Interfaces;

namespace MusicStoreCore.Data.Repositories
{
    public class AlbumDummyRepository : IAlbumRepository
    {
        public IReadOnlyList<Album> GetByGenre(int genreId)
        {
            var albums = new List<Album>();
            var nbrOfAlbums = 3;
            for (int i = 1; i <= nbrOfAlbums; i++)
            {
                albums.Add(new Album
                {
                    Id = i + (nbrOfAlbums * (genreId - 1)),
                    Artist = "Artist " + i,
                    Title = "Title " + i,
                    GenreId = genreId
                });
            }
            return albums;
        }

        public Album GetById(int id)
        {
            var genreRepo = new GenreDummyRepository();
            var genre = genreRepo.GetAll().First();

            return new Album
            {
                Id = id,
                Artist = "Artist " + id,
                Title = "Title " + id,
                GenreId = genre.Id
            };
        }
    }

}
