using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using System.Diagnostics;
	using BettingApp.Services.ViewModels;

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
		
		public IActionResult Error()
		{
			return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}
	}
}
