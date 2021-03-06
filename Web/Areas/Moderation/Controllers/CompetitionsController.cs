﻿namespace Web.Areas.Moderation.Controllers
{
	using System.Threading.Tasks;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.Utilities.Constants;
	using BettingApp.Services.ViewModels.Competition;
	using Microsoft.AspNetCore.Mvc;
	using Web.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	public class CompetitionsController : BaseController
    {
	    public ICompetitionsService CompetitionsService { get; set; }
		public ISportsService SportsService { get; }

		public CompetitionsController(ICompetitionsService competitionsService,ISportsService sportsService)
	    {
		    this.CompetitionsService = competitionsService;
		    this.SportsService = sportsService;
		}

	    public IActionResult Add()
	    {
		    return this.View();
	    }
		[HttpPost]
        public async Task<IActionResult> Add(AddCompetitionInputModel model)
        {
	        var competition = await this.CompetitionsService.Add(model);
            return this.View();
        }
    }
}