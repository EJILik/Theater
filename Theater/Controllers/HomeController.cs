using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.ViewModels;

namespace Theater.Controllers
{
    public class HomeController : Controller
    {
        private ISchedule _scheduleRep;
        public HomeController(ISchedule scheduleRep)
        {
            _scheduleRep = scheduleRep; 
        }

        public ViewResult Index()
        {
            var poster = new HomeViewModel { Schedules = _scheduleRep.Schedules.OrderBy(i => i.performanceTime) };

            return View(poster);
        }

    }
}
