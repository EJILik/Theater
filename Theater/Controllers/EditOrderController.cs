using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;
using Theater.ViewModels;
using Microsoft.AspNetCore.Http;
using Theater.Data;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace Theater.Controllers
{
	public class EditOrderController : Controller
	{
		private readonly IAllOrders allOrders;

		private readonly ShopCart shopCart;
		private readonly AppDBContent appDBContent;
		private Order order1;
		public EditOrderController(IAllOrders allOrders, ShopCart shopCart, AppDBContent _appDBContent)
		{
			this.allOrders = allOrders;
			this.shopCart = shopCart;
			appDBContent = _appDBContent;
		}

		public IActionResult EditOrder(int id)
		{
			Order ord = allOrders.Orders.FirstOrDefault(a => a.id == id);
			return View(ord);
		}
		[HttpPost]
		public IActionResult EditOrder(Order order)
		{
			if (ModelState.IsValid)
			{
				appDBContent.Order.FirstOrDefault(c => c.code == order.code).phone = order.phone;
				appDBContent.Order.FirstOrDefault(c => c.code == order.code).name = order.name;
				appDBContent.Order.FirstOrDefault(c => c.code == order.code).surname = order.surname;
				appDBContent.Order.FirstOrDefault(c => c.code == order.code).email = order.email;
				appDBContent.Order.FirstOrDefault(c => c.code == order.code).discount = order.discount;
				appDBContent.SaveChanges();
				appDBContent.Order.FirstOrDefault(c => c.code == order.code).price = allOrders.recallPrice(appDBContent.Order.FirstOrDefault(c => c.code == order.code));
				appDBContent.SaveChanges();
				return RedirectToAction("Complete");
			}
			return View(order);
		}

		public IActionResult Complete()
		{
			ViewBag.Message = "Заказ успешно изменён";
			return View();
		}


	}
}
