using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
    public class PerformanceRepository : IPerformance
    {

        private readonly AppDBContent appDBConten;

        public PerformanceRepository(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }

        public IEnumerable<Performance> Performances => appDBConten.Performance.Include(c => c.genre);


        public Performance GetPerformanceObj(int performanceId) => appDBConten.Performance.FirstOrDefault(p => p.id == performanceId);

    }
}
