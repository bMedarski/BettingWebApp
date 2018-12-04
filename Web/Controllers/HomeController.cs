﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using BettingApp.Services.Models;

	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}
	}
}