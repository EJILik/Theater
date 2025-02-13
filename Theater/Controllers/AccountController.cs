using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Theater.Data.Interfaces;
using Theater.ViewModels;
namespace Theater.Controllers
{
    public class AccountController : Controller
    {
        private ISchedule _scheduleRep;
        public AccountController(ISchedule scheduleRep)
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
