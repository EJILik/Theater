using System.Collections.Generic;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
    public class GenreRepository : IGenre
    {
        private readonly AppDBContent appDBConten;

        public GenreRepository(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }
        public IEnumerable<Genre> AllGenres => appDBConten.Genre;
    }
}
