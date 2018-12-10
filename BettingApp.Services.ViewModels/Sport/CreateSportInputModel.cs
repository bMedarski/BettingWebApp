namespace BettingApp.Services.ViewModels.Sport
{
	using System.ComponentModel.DataAnnotations;

	public class CreateSportInputModel
	{
		[Required]
		public string Name { get; set; }
	}
}
