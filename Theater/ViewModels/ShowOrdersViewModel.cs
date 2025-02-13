using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.ViewModels
{
	public class ShowOrdersViewModel
	{
		public IEnumerable<Order> Orders { get; set; }
		public IEnumerable<Schedule> Schedules { get; set; }
		public IEnumerable<ShopCartItem> ShopCartItem { get; set; }
	}
}
