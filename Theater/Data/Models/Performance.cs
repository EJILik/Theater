using System.IO;

namespace Theater.Data.Models
{
    public class Performance
    {
        public int id { get; set; }
        public string img { get; set; }
        public string performanceName { get; set; }
        public int ageRestriction { get; set; }
        public string description { get; set; }
        public virtual PerfScene perfScene { get; set; }
        public virtual Genre genre { get; set; }
        public Director director { get; set; }
        public int duration { get; set; }
        public string intermission { get; set; }
        public ActorsList actorsList { get; set; }

    }
}
