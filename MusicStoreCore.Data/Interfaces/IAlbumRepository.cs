using System.Collections.Generic;
using MusicStoreCore.Data.DomainClasses;

namespace MusicStore.Data.Interfaces
{
    public interface IAlbumRepository
    {
        IReadOnlyList<Album> GetByGenre(int genreId);
        Album GetById(int id);

    }
}
