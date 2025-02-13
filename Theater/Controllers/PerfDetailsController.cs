using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.Data.Models;
using Theater.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Theater.Controllers
{
    public class PerfDetailsController :Controller
    {
        private ISchedule _scheduleRep;
        private IActorsList _actorsListRep;
        public PerfDetailsController(ISchedule scheduleRep, IActorsList actorsListRep)
        {
            _scheduleRep = scheduleRep;
            _actorsListRep = actorsListRep;
		}

        public IActionResult Index(int id)
        {

            Schedule _scedule = _scheduleRep.Schedules.FirstOrDefault(p => p.id == id);
			HttpContext.Session.Set<Schedule>("Current", _scedule);

            var poster = new PerfDetailsViewModel { Schedule = HttpContext.Session.Get<Schedule>("Current"), Actors = _actorsListRep.actorsLists };

            return View(poster);
        }
    }
}
