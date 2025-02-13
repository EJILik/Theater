using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
	public class ScenePartRepository : IScenePart
	{
		private readonly AppDBContent appDBConten;
		public ScenePartRepository(AppDBContent appDBConten)
		{
			this.appDBConten = appDBConten;
		}
		public IEnumerable<ScenePart> currSceneParts => appDBConten.ScenePart;
	}
}
