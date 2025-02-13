using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
    public interface IGenre
    {
        IEnumerable<Genre> AllGenres { get; }
    }
}
