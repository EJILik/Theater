using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.ViewModels
{
	public class SeatsViewModel
	{
		public Schedule Schedule { get; set; }
		public IEnumerable<Ticket> Ticket { get; set; }
		public ShopCart shopCart { get; set; }
		public Order order { get; set; }
		public IEnumerable<ScenePart> SceneParts { get; set; }

	}
}
