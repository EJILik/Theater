using System.Collections.Generic;
using System;
using Theater.Data.Interfaces;
using System.Linq;
using Theater.Data.Models;
using Theater.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers
{
	public class TheaterPosterController : Controller
	{
		private ISchedule _scheduleRep;

		public TheaterPosterController(ISchedule scheduleRep)
		{
			_scheduleRep = scheduleRep;
		}


		[Route("TheaterPoster/FilteredPoster")]
		[Route("TheaterPoster/FilteredPoster/{theater}")]
		public ViewResult FilteredPoster(string theater)
		{
			string _theater = theater;
			IEnumerable<Schedule> schedule = null;
			string currTheater = "";
			if (string.IsNullOrEmpty(theater))
			{
				schedule = _scheduleRep.Schedules.OrderBy(i => i.performanceTime);
			}
			else
			{
				if (string.Equals("Театр-Театр", theater, StringComparison.OrdinalIgnoreCase))
				{
					schedule = _scheduleRep.Schedules.Where(i => i.Performance.perfScene.theatre.theatreName.Equals("Театр-Театр")).OrderBy(i => i.id);
				}
				else if (string.Equals("Театр У Моста", theater, StringComparison.OrdinalIgnoreCase))
				{
					schedule = _scheduleRep.Schedules.Where(i => i.Performance.perfScene.theatre.theatreName.Equals("Театр \"У Моста\"")).OrderBy(i => i.id);
				}
				else if (string.Equals("Театр Юного Зрителя", theater, StringComparison.OrdinalIgnoreCase))
				{
					schedule = _scheduleRep.Schedules.Where(i => i.Performance.perfScene.theatre.theatreName.Equals("ТЮЗ")).OrderBy(i => i.id);
				}
				currTheater = _theater;


			}

			var theaterObj = new TheaterPosterViewModel
			{
				Schedules = schedule,
				currTheater = currTheater
			};

			return View(theaterObj);
		}

	}
}
