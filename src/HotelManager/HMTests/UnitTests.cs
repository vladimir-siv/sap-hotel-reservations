using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HMCore;
using HMCore.Database;
using HMCore.Models;

namespace HMTests
{
	[TestClass]
	public class UnitTests
	{
		#region House Keeping

		public TestContext TestContext { get; set; }

		[TestInitialize]
		public void TestInitialize()
		{
			try
			{
				App.Init(ConfigurationManager.AppSettings);
			}
			catch (Exception ex)
			{
				TestContext.WriteLine(ex.ToFullErrorMessage());
				throw ex;
			}
		}

		[TestCleanup]
		public void TestCleanup()
		{
			try
			{
				App.Dispose();
			}
			catch (Exception ex)
			{
				TestContext.Write(ex.ToFullErrorMessage());
				throw ex;
			}
		}

		#endregion

		[TestMethod]
		public void TestCase1()
		{
			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, 1u);

			Reservation reservation;

			// 1a)
			reservation = db.MakeReservation(db.DefaultHotel, -4, 2);
			Assert.AreEqual(null, reservation);

			// 1b)
			reservation = db.MakeReservation(db.DefaultHotel, 200, 400);
			Assert.AreEqual(null, reservation);
		}

		[TestMethod]
		public void TestCase2()
		{
			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, 3u);

			Reservation r1 = db.MakeReservation(db.DefaultHotel, 0, 5);
			Reservation r2 = db.MakeReservation(db.DefaultHotel, 7, 13);
			Reservation r3 = db.MakeReservation(db.DefaultHotel, 3, 9);
			Reservation r4 = db.MakeReservation(db.DefaultHotel, 5, 7);
			Reservation r5 = db.MakeReservation(db.DefaultHotel, 6, 6);
			Reservation r6 = db.MakeReservation(db.DefaultHotel, 0, 4);

			Assert.AreNotEqual(null, r1);
			Assert.AreNotEqual(null, r2);
			Assert.AreNotEqual(null, r3);
			Assert.AreNotEqual(null, r4);
			Assert.AreNotEqual(null, r5);
			Assert.AreNotEqual(null, r6);
		}

		[TestMethod]
		public void TestCase3()
		{
			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, 3u);

			Reservation r1 = db.MakeReservation(db.DefaultHotel, 1, 3);
			Reservation r2 = db.MakeReservation(db.DefaultHotel, 2, 5);
			Reservation r3 = db.MakeReservation(db.DefaultHotel, 1, 9);
			Reservation r4 = db.MakeReservation(db.DefaultHotel, 0, 15);

			Assert.AreNotEqual(null, r1);
			Assert.AreNotEqual(null, r2);
			Assert.AreNotEqual(null, r3);
			Assert.AreEqual(null, r4);

			// TestCase3 bonus =)
			// It is possible to add new rooms in the middle of the application,
			// maybe they have hired a construction company to build another floor. :)
			db.AddRoom(db.DefaultHotel);

			r4 = db.MakeReservation(db.DefaultHotel, 0, 15);
			Assert.AreNotEqual(null, r4); // Previously not possible, now is.
		}

		[TestMethod]
		public void TestCase4()
		{
			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, 3u);

			Reservation r1 = db.MakeReservation(db.DefaultHotel, 1, 3);
			Reservation r2 = db.MakeReservation(db.DefaultHotel, 0, 15);
			Reservation r3 = db.MakeReservation(db.DefaultHotel, 1, 9);
			Reservation r4 = db.MakeReservation(db.DefaultHotel, 2, 5);
			Reservation r5 = db.MakeReservation(db.DefaultHotel, 4, 9);

			Assert.AreNotEqual(null, r1);
			Assert.AreNotEqual(null, r2);
			Assert.AreNotEqual(null, r3);
			Assert.AreEqual(null, r4);
			Assert.AreNotEqual(null, r5);
		}

		[TestMethod]
		public void TestCase5()
		{
			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, 2u);

			Reservation r1 = db.MakeReservation(db.DefaultHotel, 1, 3);
			Reservation r2 = db.MakeReservation(db.DefaultHotel, 0, 4);
			Reservation r3 = db.MakeReservation(db.DefaultHotel, 2, 3);
			Reservation r4 = db.MakeReservation(db.DefaultHotel, 5, 5);
			Reservation r5 = db.MakeReservation(db.DefaultHotel, 4, 10);
			Reservation r6 = db.MakeReservation(db.DefaultHotel, 10, 10);
			Reservation r7 = db.MakeReservation(db.DefaultHotel, 6, 7);
			Reservation r8 = db.MakeReservation(db.DefaultHotel, 8, 10);
			Reservation r9 = db.MakeReservation(db.DefaultHotel, 8, 9);

			Assert.AreNotEqual(null, r1);
			Assert.AreNotEqual(null, r2);
			Assert.AreEqual(null, r3);
			Assert.AreNotEqual(null, r4);
			Assert.AreNotEqual(null, r5);
			Assert.AreNotEqual(null, r6);
			Assert.AreNotEqual(null, r7);
			Assert.AreEqual(null, r8);
			Assert.AreNotEqual(null, r9);
		}
	}
}
