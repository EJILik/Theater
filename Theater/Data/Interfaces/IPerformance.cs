using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
    public interface IPerformance
    {
        IEnumerable<Performance> Performances { get; }

        Performance GetPerformanceObj(int performanceId);
    }
}
