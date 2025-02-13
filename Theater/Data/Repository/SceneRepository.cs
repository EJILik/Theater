using Theater.Data.Interfaces;

namespace Theater.Data.Repository
{
    public class SceneRepository : IScene
    {
        private readonly AppDBContent appDBConten;

        public SceneRepository(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }
    }
}
