using System;
using System.Collections.Generic;
using System.Configuration;
using HMCore;
using HMCore.Database;
using HMCore.Models;

namespace HMConsoleClient
{
	public static class Program
	{
		private static void Main()
		{
			// .NET Core Console Test App

			try
			{
				App.Init(ConfigurationManager.AppSettings);

				Run();
			}
			finally
			{
				App.Dispose();
			}

			Console.WriteLine();
			Console.WriteLine("====================================================================");
			Console.WriteLine("Application has successfully ended. Press any key to exit . . .");
			Console.ReadKey(true);
		}

		private static void Run()
		{
			List<(int, int)> requests = new List<(int, int)>()
			{
				(1, 3),
				(0, 4),
				(2, 3),
				(5, 5),
				(4, 10),
				(10, 10),
				(6, 7),
				(8, 10),
				(8, 9),
			};

			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, 2u);

			foreach (var req in requests)
			{
				Reservation r = db.MakeReservation(db.DefaultHotel, req.Item1, req.Item2);
				Console.WriteLine($"Requesting {req.Item1} - {req.Item2}:\t{(r != null ? "Accepted" : "Declined")}");
			}
		}
	}
}
