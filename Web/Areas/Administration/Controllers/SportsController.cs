namespace Web.Areas.Administration.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.Utilities.Constants;
	using BettingApp.Services.ViewModels.Sport;
	using Microsoft.AspNetCore.Mvc;
	using Web.Controllers;

	[Area(GlobalConstants.AdministrationAreaText)]
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
		    var sportId = await this.SportsService.Add(model);
		    return this.View();
	    }
	    [HttpGet]
	    public JsonResult AllSports()
	    {
		    var sports = this.SportsService.GetAllSports().ToList();
		    return this.Json(sports);
	    }
    }
}