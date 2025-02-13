using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
	public class TicketRepository : ITicket
	{
		private readonly AppDBContent appDBConten;
		public TicketRepository(AppDBContent appDBConten)
		{
			this.appDBConten = appDBConten;
		}
		public IEnumerable<Ticket> currTickets => appDBConten.Ticket.Include(c => c.status).Include(c => c.place.scenePart);
	}
}
