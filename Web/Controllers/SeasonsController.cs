using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using BettingApp.Data.Common;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.Season;

	public class SeasonsController : BaseController
    {

	    public ISeasonsService SeasonsService { get; set; }
		public ISportsService SportsService { get; }

		public SeasonsController(ISeasonsService seasonsService,ISportsService sportsService)
	    {
		    this.SeasonsService = seasonsService;
		    this.SportsService = sportsService;
		}

        public IActionResult Create()
        {
	        var sports = this.SportsService.GetAllAsSelectLisItems().ToList();
			//TODO to return status code 201
            return this.View(new CreateSeasonInputModel{Sports=sports});
        }

		[HttpPost]
	    public async Task<IActionResult> Create(CreateSeasonInputModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }
		    var seasonId = await this.SeasonsService.Create(model);
		    return this.RedirectToAction(actionName: "Index", controllerName: "Home");
	    }

	    [HttpPost]
	    public JsonResult AllSeasons(int sport)
	    {
		    var seasons = this.SeasonsService.GetAllAsSelectLisItems(sport).ToList();
		    return this.Json(seasons);
	    }
    }
}