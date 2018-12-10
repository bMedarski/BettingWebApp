using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using System.Threading.Tasks;
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
	    public async Task<IActionResult> Create(CreateSportInputModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }

		    var sportId = await this.SportsService.CreateAsync(model);
		    return this.RedirectToAction(actionName:"Index",controllerName:"Home");
	    }
    }
}