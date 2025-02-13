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
	public class SeatsController : Controller
	{
		private ISchedule _scheduleRep;
		private IScenePart _scenePartRep;
		private ITicket _ticketRep;
		private AppDBContent _appDBContent;
		private readonly ShopCart _shopCart;


		public SeatsController(ISchedule scheduleRep, IScenePart scenePartRep, ITicket ticketRep,AppDBContent appDBContent, ShopCart shopCart)
		{
			_scheduleRep = scheduleRep;
			_scenePartRep = scenePartRep;
			_ticketRep = ticketRep;
			_appDBContent = appDBContent;
			_shopCart = shopCart;
		}
		public ViewResult Seats()
		{
			var items = _shopCart.getShopItems().OrderBy(c => c.ticket.place.scenePart).ToList();
			_shopCart.listShopItems = items;

			Schedule _schedule = HttpContext.Session.Get<Schedule>("Current");
			var poster = new SeatsViewModel { Schedule = _schedule, Ticket = _ticketRep.currTickets.Where(c=>c.scheduleId== _schedule.id).OrderBy(i => i.place.row).ToList(), shopCart = _shopCart, SceneParts = _scenePartRep.currSceneParts.Where(c=>c.sceneId == _schedule.Performance.perfScene.scene.id) };
			return View(poster);
		}

		public RedirectToActionResult addToOrderList(int id)
		{
            var shopitems = _shopCart.getShopItems();
            var item = _ticketRep.currTickets.FirstOrDefault(i => i.id == id);
			if (item != null && item.status.id == 1)
			{
				if (shopitems.Count == 0)
				{
					_shopCart.AddToCart(item);
				}
				else
				{
					ShopCartItem sci = shopitems.FirstOrDefault(d => d.ticket == item);
					if (sci == null)
					{
                        _shopCart.AddToCart(item);
                    }
				}
			}
			return RedirectToAction("Seats");
		}
		
		public RedirectToActionResult deleteFromCart(int id)
		{
			var shopitems = _shopCart.getShopItems();

			if (shopitems.Count != 0)
			{
				var item = shopitems.FirstOrDefault(i => i.id == id);
				if (item != null)
				{
					_shopCart.DeleteFromCart(item);
				}
			}
			return RedirectToAction("Seats");
		}
		public RedirectToActionResult addOrder(int id)
		{
			Schedule _scedule = _scheduleRep.Schedules.FirstOrDefault(p => p.id == id);
			HttpContext.Session.Set<Schedule>("Current", _scedule);
			return RedirectToAction("Seats");
		}
	}
}
