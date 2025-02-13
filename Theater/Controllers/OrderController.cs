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
    public class OrderController : Controller
    {
        private ISchedule _scheduleRep;
        private IScenePart _scenePartRep;
        private ITicket _ticketRep;
        private AppDBContent _appDBContent;

        private readonly IAllOrders allOrders;

        private readonly ShopCart _shopCart;


        public ViewResult Seats()
        {
            var items = _shopCart.getShopItems().OrderBy(c => c.ticket.place.scenePart).ToList();
            _shopCart.listShopItems = items;

            Schedule _schedule = HttpContext.Session.Get<Schedule>("Current");
            var poster = new SeatsViewModel { Schedule = _schedule, Ticket = _ticketRep.currTickets.Where(c => c.scheduleId == _schedule.id).OrderBy(i => i.place.row).ToList(), shopCart = _shopCart, SceneParts = _scenePartRep.currSceneParts.Where(c => c.sceneId == _schedule.Performance.perfScene.scene.id) };
            return View(poster);
        }

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this._shopCart = shopCart;
        }
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order) //ВОЗМОЖНО НЕОБХОДИМО ИСПРАВЛЕНИЕ НА IActionResult
        {
            _shopCart.listShopItems = _shopCart.getShopItems();
            
            if (_shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары в корзине");
            }
            if (ModelState.IsValid)
            {
				Order ord = allOrders.createOrder(order);

				return RedirectToAction("Complete", ord.tickets);
            }
            return View(order);
        }

        public IActionResult Complete(Order order)
        {

            ViewBag.Message = "Заказ успешно обработан";
            return View(order);
        }
    }
}
