namespace BettingApp.Services.Utilities.Constants
{
	using System.Reflection.Metadata;

	public class InputModelsConstants
	{
		public const string RequiredErrorMessage = "The field is Required!";
		public const string ComparePasswordErrorMessage = "Password and confirm password must be the same";

		public const string UsernameInvalidErrorMessage = "Username is not valid";
		public const string EmailInvalidErrorMessage = "Email is not valid";

		public const string UsernameRegularExpressionFormat = "[a-zA-Z0-9-*_~.]+";
		public const string EmailRegularExpressionFormat = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
		                                                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
		                                                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

		public const int UsernameMinimumLength = 3;
		public const string UsernameLengthErrorMessage = "Length must be more then 3";
		public const int PasswordMinimumLength = 5;
		public const string PasswordLengthErrorMessage = "Length must be more then 5";
	}
}
