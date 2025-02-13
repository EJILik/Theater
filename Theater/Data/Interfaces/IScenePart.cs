using System.Collections;
using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
	public interface IScenePart
	{
		public IEnumerable<ScenePart> currSceneParts { get; }
	}
}
