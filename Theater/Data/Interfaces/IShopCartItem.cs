using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
	public interface IShopCartItem
	{
		IEnumerable<ShopCartItem> shopCartItems { get; }
	}
}
