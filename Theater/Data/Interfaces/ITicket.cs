using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
	public interface ITicket
	{
		public IEnumerable<Ticket> currTickets { get; }
	}
}
