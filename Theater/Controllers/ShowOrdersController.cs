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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Theater.Controllers
{
	[Authorize(Roles = "Administrator")]
	public class ShowOrdersController:Controller
	{
		private readonly IAllOrders allOrders;
		private readonly AppDBContent appDBContent;
		private readonly IShopCartItem shopCartItem;
		private readonly ISchedule schedule;

		public ShowOrdersController(IAllOrders allOrders, AppDBContent _appDbContent, IShopCartItem _shopCartItem, ISchedule _schedule)
		{
			this.allOrders = allOrders;
			appDBContent = _appDbContent;
			this.shopCartItem = _shopCartItem;
			schedule = _schedule;
		}
		public ViewResult ShowOrders()
		{
			var poster = new ShowOrdersViewModel {Orders = allOrders.Orders,ShopCartItem = appDBContent.ShopCartItem.Include(c=>c.ticket.place.scenePart), Schedules = schedule.Schedules};
			return View(poster);
		}
	

	}
}
