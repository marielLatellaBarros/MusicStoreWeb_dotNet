using System.Collections.Generic;
using MusicStoreCore.Data.DomainClasses;

namespace MusicStore.Data.Interfaces
{
    public interface IGenreRepository
    {
        IReadOnlyList<Genre> GetAll();
        Genre GetById(int id);
    }
}