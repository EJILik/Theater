using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
    public interface ISchedule
    {
        IEnumerable<Schedule> Schedules { get; }
        Schedule GetSchedule(int id);
    }
}
