using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
    public class PerformanceActorRepository : IPerformanceActor
    {
        private readonly AppDBContent appDBConten;
        public PerformanceActorRepository(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }

		public IEnumerable<PerformanceActor> PerformanceActors => throw new System.NotImplementedException();

		public PerformanceActor GetPerformanceActor(int scheduleId)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<PerformanceActor> GetPerformanceActors(int scheduleId)
		{
			throw new System.NotImplementedException();
		}
	}
}
