namespace BettingApp.Services.ViewModels.Position
{
	using System.ComponentModel.DataAnnotations;
	using Utilities.Constants;

	public class AddPositionInputModel
	{
		public string Name { get; set; }
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public string SportId { get; set; }
	}
}
