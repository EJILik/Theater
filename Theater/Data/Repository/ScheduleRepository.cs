using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
    public class ScheduleRepository : ISchedule
    {
        private readonly AppDBContent appDBConten;
        public ScheduleRepository(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }
        public IEnumerable<Schedule> Schedules => appDBConten.Schedule.Include(c => c.Performance.perfScene.theatre).Include(c => c.Performance.perfScene.scene).Include(c => c.Performance.genre).Include( c => c.Performance.actorsList.performanceActor).Include(c => c.Performance.director);
        public Schedule GetSchedule(int id) => appDBConten.Schedule.FirstOrDefault(p => p.id == id);

	}
}
