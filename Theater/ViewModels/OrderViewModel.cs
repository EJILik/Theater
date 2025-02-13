using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.ViewModels
{
	public class OrderViewModel
	{
        public ShopCart shopCart { get; set; }
        public IEnumerable<ScenePart> SceneParts { get; set; }
        public Order order { get; set; }
        public Schedule Schedule { get; set; }
        public IEnumerable<Ticket> Ticket { get; set; }

    }
}
