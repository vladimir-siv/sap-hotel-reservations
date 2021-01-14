using System;
using System.Configuration;
using HMCore;
using HMCore.Database;

namespace HMConsoleClient
{
	public class Program
	{
		private static void Main()
		{
			App.Init(ConfigurationManager.AppSettings);

			HMDatabase db = Dependency.Resolve<HMDatabase>();

			Console.WriteLine(db.DefaultHotel.Name);

			App.Dispose();

			Console.WriteLine("Press any key to exit . . .");
			Console.ReadKey(true);
		}
	}
}
