namespace Web.Areas.Administration.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.Sport;
	using Microsoft.AspNetCore.Mvc;
	using Web.Controllers;

	public class SportsController : BaseController
    {
	    public ISportsService SportsService { get; set; }

	    public SportsController(ISportsService sportsService)
	    {
		    this.SportsService = sportsService;
	    }

        public IActionResult Add()
        {
            return this.View();
        }

		[HttpPost]
	    public async Task<IActionResult> Add(AddSportInputModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }

		    var sportId = await this.SportsService.Add(model);
		    return this.View();
	    }
	    [HttpGet]
	    public JsonResult AllSports()
	    {
		    var seasons = this.SportsService.GetAllSports().ToList();
		    return this.Json(seasons);
	    }
    }
}