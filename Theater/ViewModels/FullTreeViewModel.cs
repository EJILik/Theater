using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.ViewModels
{
	public class FullTreeViewModel
	{
		public IEnumerable<Ticket> Ticket { get; set; }
		public ScenePart ScenePart { get; set; }
	}
}
