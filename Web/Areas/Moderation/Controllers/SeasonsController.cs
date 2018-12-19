namespace Web.Areas.Moderation.Controllers
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.Utilities.Constants;
	using BettingApp.Services.ViewModels.Season;
	using Microsoft.AspNetCore.Mvc;
	using Web.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	public class SeasonsController : BaseController
    {

	    public ISeasonsService SeasonsService { get; set; }
		public ISportsService SportsService { get; }

		public SeasonsController(ISeasonsService seasonsService,ISportsService sportsService)
	    {
		    this.SeasonsService = seasonsService;
		    this.SportsService = sportsService;
		}

        public IActionResult Add()
        {
            return this.View();
        }

		[HttpPost]
	    public async Task<IActionResult> Add(AddSeasonInputModel model)
		{

			//var start = DateTime.Parse(model.Start);


		    var season = await this.SeasonsService.Add(model);
		    return this.View();
	    }

	    [HttpPost]
	    public JsonResult AllSeasons(int sport)
	    {
		    var seasons = this.SeasonsService.GetAllSeasons(sport).ToList();
		    return this.Json(seasons);
	    }
    }
}