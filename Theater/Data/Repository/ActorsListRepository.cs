using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
	public class ActorsListRepository : IActorsList
	{
		private readonly AppDBContent appDBConten;
		public ActorsListRepository(AppDBContent appDBConten)
		{
			this.appDBConten = appDBConten;
		}
		public IEnumerable<ActorsList> actorsLists => appDBConten.ActorsList.Include(c => c.performanceActor).Include(c => c.performanceActor.actor).Include(c => c.performanceActor.role);
	}
};
