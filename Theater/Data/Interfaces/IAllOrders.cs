using System.Collections;
using System.Collections.Generic;
using Theater.Data.Models;

namespace Theater.Data.Interfaces
{
    public interface IAllOrders
    {
        Order createOrder(Order order);
		double recallPrice(Order order);
		IEnumerable<Order> Orders { get; }

	}
}
