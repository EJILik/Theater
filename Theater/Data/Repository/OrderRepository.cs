using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;


namespace Theater.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent appDBConten;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDBContent appDBConten, ShopCart shopCart)
        {
            this.appDBConten = appDBConten;
            this.shopCart = shopCart;
        }
		public IEnumerable<Order> Orders => appDBConten.Order;
        public double recallPrice(Order order)
        {
			double a = 100.0 - order.discount;
            double k = 100.0;
			double newprice = order.price * a / k;

			return newprice;
        }
		public Order createOrder(Order order)
        {
			double price = 0;
            order.orderTime = DateTime.Now;
            order.tickets = new List<ShopCartItem>();
            List<ShopCartItem> items = new List<ShopCartItem>(shopCart.getShopItems().ToList());
			foreach (var item in items)
            {
				var status = appDBConten.TicketStatus.FirstOrDefault(c => c.ticketStatusName == "Куплен");
                price = price + item.price;
				ShopCartItem temp = new ShopCartItem {ticket=item.ticket, Status = status,price=item.price};
                item.ticket.status = status;

                Random random =   new Random();
                order.code = random.Next(2147483647);
                order.tickets.Add(temp);
                shopCart.DeleteFromCart(item);
                
            }
            order.price = price;
			appDBConten.Order.Add(order);
			appDBConten.SaveChanges();
			

            return order;
        }
    }
}
