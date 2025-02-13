using System.Data;

namespace Theater.Data.Models
{
    public class PerformanceActor
    {
        public int id { get; set; }
        public Role role { get; set; }
        public Actor actor { get; set; }
    }
}
