namespace BettingApp.Services.ViewModels.Sport
{
	using System.ComponentModel.DataAnnotations;

	public class AddSportInputModel
	{
		[Required]
		public string Name { get; set; }
	}
}
