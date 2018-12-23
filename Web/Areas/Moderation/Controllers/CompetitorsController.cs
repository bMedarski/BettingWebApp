namespace Web.Areas.Moderation.Controllers
{
	using System.Linq;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.Utilities.Constants;
	using BettingApp.Services.ViewModels.Competitor;
	using Microsoft.AspNetCore.Mvc;
	using Web.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	public class CompetitorsController : BaseController
    {
		private readonly ICompetitorsService _competitorsService;

		public CompetitorsController(ICompetitorsService competitorsService)
	    {
			this._competitorsService = competitorsService;
		}

        public IActionResult AddTeam()
        {
            return this.View();
        }

		[HttpPost]
	    public IActionResult AddTeam(AddTeamInputModel model)
		{
			var team = this._competitorsService.AddTeam(model);
			return this.RedirectToAction("AddTeam");
		}
	    public IActionResult AddPlayer()
	    {
		    return this.View();
	    }
	    [HttpPost]
	    public IActionResult AddPlayer(AddPlayerInputModel model)
	    {
		    var player = this._competitorsService.AddPlayer(model);
		    return this.RedirectToAction("AddPlayer");
	    }
	    [HttpPost]
	    public JsonResult AllTeams(int sport)
	    {
		    var seasons = this._competitorsService.GetAllTeams(sport).ToList();
		    return this.Json(seasons);
	    }
    }
}