using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Theater.Data.Interfaces;
using Theater.Data.Models;

namespace Theater.Data.Repository
{
	public class ShopCartItemRepository : IShopCartItem
	{
		private readonly AppDBContent appDBConten;
		public ShopCartItemRepository(AppDBContent appDBConten)
		{
			this.appDBConten = appDBConten;
		}
		public IEnumerable<ShopCartItem> shopCartItems => appDBConten.ShopCartItem.Include(c=>c.Status).Include(c=>c.ticket).Include(c => c.ticket.place.scenePart);
	}
}
