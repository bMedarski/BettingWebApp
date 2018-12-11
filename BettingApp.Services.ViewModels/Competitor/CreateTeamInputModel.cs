﻿namespace BettingApp.Services.ViewModels.Competitor
{
	using Data.Common.Enums;

	public class CreateTeamInputModel
	{
		public string Name { get; set; }
		public string LogoUrl { get; set; }
		public Country Country { get; set; }
	}
}
