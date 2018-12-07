using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using BettingApp.Services.ViewModels.Season;

	public class SeasonsController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }

		[HttpPost]
	    public IActionResult Create(CreateSeasonInputModel model)
	    {
		    return this.View();
	    }
    }
}