using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.ViewModels
{
    public class PerfDetailsViewModel
    {
        public Schedule Schedule { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<ActorsList> Actors { get; set; }
        //public int DetailId { get; set; }
    }
}
