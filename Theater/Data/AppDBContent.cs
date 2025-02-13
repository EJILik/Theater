using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using Theater.Areas.Identity;
using Theater.Data.Models;
using static System.Formats.Asn1.AsnWriter;

namespace Theater.Data
{
    public class AppDBContent : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
	{
		public AppDBContent(DbContextOptions<AppDBContent> options)
			: base(options)
		{
		}
		public DbSet<Performance> Performance { get; set; }
		public DbSet<Genre> Genre { get; set; }
		public DbSet<Scene> Scene { get; set; }
		public DbSet<Theatre> Theatre { get; set; }
		public DbSet<Place> Place { get; set; }
		public DbSet<TicketStatus> TicketStatus { get; set; }
		public DbSet<PerformanceActor> PerformanceActor { get; set; }
		public DbSet<Actor> Actor { get; set; }
		public DbSet<Role> Role { get; set; }
		public DbSet<Director> Director { get; set; }
		public DbSet<Schedule> Schedule { get; set; }
		public DbSet<PerfScene> PerfScene { get; set; }
		public DbSet<ActorsList> ActorsList { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<ScenePart> ScenePart { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
		public DbSet<ShopCart> ShopCart { get; set; }
		public DbSet<ShopCartItem> ShopCartItem { get; set; }
	}
}
