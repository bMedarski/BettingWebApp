namespace BettingApp.Services.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;

	public class RegisterUserInputModel
	{
		[MinLength(3)]
		[RegularExpression("[a-zA-Z0-9-*_~.]+")]
		public string Username { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[MinLength(5)]
		public string Password { get; set; }

		[Display(Name = "Confirm password")]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

	}
}
