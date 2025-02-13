using System.Collections.Generic;
using Theater.Data.Models;
using System.Collections;

namespace Theater.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
