﻿namespace BettingApp.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using ViewModels.Competition;

	public interface ICompetitionsService
	{
		Task<int> Add(AddCompetitionInputModel model);
	}
}
