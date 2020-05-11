using System.Collections.Generic;
using MusicStoreCore.Data.DomainClasses;

namespace MusicStoreCore.Data.Interfaces
{
    public interface IGenreRepository
    {
        IList<Genre> GetAll();
    }
}