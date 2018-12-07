using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.Competition;

	public class CompetitionsController : BaseController
    {
	    public ICompetitionsService CompetitionsService { get; set; }

	    public CompetitionsController(ICompetitionsService competitionsService)
	    {
		    this.CompetitionsService = competitionsService;
	    }


	    public IActionResult Create()
	    {
		    return this.View();
	    }
		[HttpPost]
        public IActionResult Create(CreateCompetitionInputModel model)
        {
	        var competition = this.CompetitionsService.CreateAsync(model);
            return this.View();
        }
    }
}