using System;
namespace DDD.Library.Helpers
{
	public static class GuardHelper
	{
		static bool IsEmpty(string value)
		{

			return string.IsNullOrEmpty(value as string) || string.IsNullOrWhiteSpace(value as string);
		}
	}
}

