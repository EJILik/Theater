using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
	public interface IActorsList
	{
		public IEnumerable<ActorsList> actorsLists { get; }
	}
}
