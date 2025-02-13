using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
    public interface IPerformanceActor
    {
        IEnumerable<PerformanceActor> PerformanceActors { get; }
        public IEnumerable<PerformanceActor> GetPerformanceActors(int scheduleId);
        PerformanceActor GetPerformanceActor(int scheduleId);

    }
}
