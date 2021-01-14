using System;

namespace HMCore
{
	public static class Config
	{
		public const int MinDay = 0;
		public const int MaxDay = 365;

		static Config()
		{
			if (MinDay > MaxDay) throw new ApplicationException("Core configuration property 'MinDay' cannot be greater than 'MaxDay'.");
		}
	}
}
