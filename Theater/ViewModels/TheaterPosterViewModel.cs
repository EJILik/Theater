using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.ViewModels
{
	public class TheaterPosterViewModel
	{

		public IEnumerable<Schedule> Schedules { get; set; }
		public string currTheater { get; set; }
	}
}
