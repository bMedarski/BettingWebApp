//namespace Web.Middleware
//{
//	using System;
//	using Microsoft.AspNetCore.Mvc;
//	using Microsoft.AspNetCore.Mvc.Filters;
//	using Microsoft.AspNetCore.Mvc.ModelBinding;
//	using Microsoft.AspNetCore.Mvc.ViewFeatures;

//	public class CustomExceptionFilter : ExceptionFilterAttribute
//	{
//		public override void OnException(ExceptionContext context)
//		{
//			string message;

//			if (context.Exception is BindingException)
//			{
//				var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
//				message = string.Join(Environment.NewLine, errors);

//				var result = new ViewResult { ViewName = "CustomError" };
//				var modelMetadata = new EmptyModelMetadataProvider();

//				result.ViewData = new ViewDataDictionary(
//					modelMetadata,
//					context.ModelState)
//				{
//					Model = message,
//				};

//				context.ExceptionHandled = true;
//				context.Result = result;

//				base.OnException(context);
//			}
//			else if (context.Exception is NotEnoughTickets)
//			{
//				message = context.Exception.Message;
//				var result = new ViewResult { ViewName = "CustomError" };
//				var modelMetadata = new EmptyModelMetadataProvider();
//				result.ViewData = new ViewDataDictionary(
//					modelMetadata,
//					context.ModelState)
//				{
//					Model = message,
//				};
//				context.ExceptionHandled = true;
//				context.Result = result;
//				base.OnException(context);
//			}
//		}
//	}
//}
