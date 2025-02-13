using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace Theater.Data.Models
{
    public class ShopCart
    {
        public int id { get; set; }
        private readonly AppDBContent appDBConten;
        public ShopCart(AppDBContent appDBConten)
        {
            this.appDBConten = appDBConten;
        }
        public string SCId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", ShopCartId);
            return new ShopCart(context) { SCId = ShopCartId };
        }
        public void AddToCart(Ticket ticket)
        {
			//ticket.status = appDBConten.TicketStatus.FirstOrDefault(c =>c.ticketStatusName == "Забронирован");
			appDBConten.ShopCartItem.Add(new ShopCartItem
            {
                ShopCId =SCId,
                ticket = ticket,
                price = ticket.price,
                Status = ticket.status
			});
            
            appDBConten.SaveChanges();
        }
		public void DeleteFromCart(ShopCartItem shopCartItem)
		{
            //ticket.status = appDBConten.TicketStatus.FirstOrDefault(c =>c.ticketStatusName == "Забронирован");
            appDBConten.ShopCartItem.Remove(shopCartItem) ;
			appDBConten.SaveChanges();
		}

		public List<ShopCartItem> getShopItems()
        {
            List<ShopCartItem> TestList = appDBConten.ShopCartItem.Where(c => c.ShopCId == SCId).Include(s => s.ticket.place).Include(s => s.ticket.status).ToList();
            return TestList;
        }
    }
}
