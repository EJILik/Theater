using Theater.Data.Interfaces;

namespace Theater.Data.Repository
{
    public class TheatreRepository 
    {
        private readonly AppDBContent appDBConten;

        public TheatreRepository(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }
    }
}
