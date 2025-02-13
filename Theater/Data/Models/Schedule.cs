using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Theater.Data.Models
{
    public class Schedule
    {
		private readonly AppDBContent appDBConten;

		public Schedule(AppDBContent appDBConten)
		{
			this.appDBConten = appDBConten;
		}
		public Schedule()
		{

		}

		public int id { get; set; }
        public virtual Performance Performance { get; set; }
        public DateTime performanceTime { get; set; }

		public static Schedule GetSchedule(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDBContent>();
			string id = session.GetString("ScheduleId") ?? Guid.NewGuid().ToString();
			session.SetString("ScheduleId", id);
			return new Schedule(context) { id = Convert.ToInt32(id) };
		}



	}
}
