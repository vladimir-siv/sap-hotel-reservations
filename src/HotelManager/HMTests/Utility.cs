using System;

namespace HMTests
{
	public static class Utility
	{
		public static string ToErrorMessage(this Exception ex)
		{
			return $"{ex.GetType().FullName}: {ex.Message}\r\n{ex.StackTrace}";
		}
		public static string ToFullErrorMessage(this Exception ex)
		{
			string message = $"An exception has occured.\r\n{ex.ToErrorMessage()}";
			
			if (ex.InnerException != null)
			{
				message += $"\r\nInner exception:\r\n{ex.InnerException.ToErrorMessage()}";
			}

			return message;
		}
	}
}
