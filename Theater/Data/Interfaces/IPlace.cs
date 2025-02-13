using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
    public interface IPlace
    {
		public IEnumerable<Place> currTicketS { get; }
	}
}
