using Theater.Data.Interfaces;
using System.Collections.Generic;
using Theater.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Theater.Data.Repository
{
    public class PlaceRepository : IPlace
    {
		private readonly AppDBContent appDBConten;
		public PlaceRepository(AppDBContent appDBConten)
		{
			this.appDBConten = appDBConten;
		}
		public IEnumerable<Place> currTicketS => appDBConten.Place.Include(c => c.scenePart);
	}
}
