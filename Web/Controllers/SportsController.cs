using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.Sport;

	public class SportsController : BaseController
    {
	    public ISportsService SportsService { get; set; }

	    public SportsController(ISportsService sportsService)
	    {
		    this.SportsService = sportsService;
	    }

        public IActionResult Create()
        {
            return this.View();
        }

		[HttpPost]
	    public IActionResult Create(CreateSportInputModel model)
	    {
		    return this.View();
	    }
    }
}