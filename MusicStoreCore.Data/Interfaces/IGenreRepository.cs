using System.Collections.Generic;
using MusicStoreCore.Data.DomainClasses;

namespace MusicStoreCore.Data.Interfaces
{
    public interface IGenreRepository
    {
        IReadOnlyList<Genre> GetAll();
    }
}