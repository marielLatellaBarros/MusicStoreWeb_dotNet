using MusicStoreCore.Data.DomainClasses;
using System.Collections.Generic;

namespace MusicStoreCore.Data.Interfaces
{
    public interface IAlbumRepository
    {
        IReadOnlyList<Album> GetByGenre(int genreId);
        Album GetById(int id);

    }
}
