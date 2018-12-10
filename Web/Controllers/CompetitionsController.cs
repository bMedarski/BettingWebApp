using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	using System.Linq;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.Competition;

	public class CompetitionsController : BaseController
    {
	    public ICompetitionsService CompetitionsService { get; set; }
		public ISportsService SportsService { get; }

		public CompetitionsController(ICompetitionsService competitionsService,ISportsService sportsService)
	    {
		    this.CompetitionsService = competitionsService;
		    this.SportsService = sportsService;
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