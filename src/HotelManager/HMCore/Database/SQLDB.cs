using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HMCore.Models;

namespace HMCore.Database
{
	// This file represents just a semi-C# semi-pseudocode file which explains
	// how the application could potentially be extended to use an SQL database,
	// so that the data could be persisted and used by multiple seperate clients.
	// It is not included in the project, hence not compiled and no errors.

	public class HotelManagerContext : DbContext
	{
		// Of course, we need a connection string in the config file, but let's assume we have that.
		public HotelManagerContext() : base("name=HotelManagerContext") { }

		public virtual DbSet<Hotel> Hotels { get; set; }
		public virtual DbSet<Reservation> Reservations { get; set; }
	}

	public class SQLDB : HMDatabase
	{
		private readonly HotelManagerContext DBContext = new HotelManagerContext();

		protected override IQueryable<Hotel>		Hotels			=> DBContext.Hotels;
		protected override IQueryable<Reservation>	Reservations	=> DBContext.Reservations;

		public override Hotel DefaultHotel => Hotels.FirstOrDefault(); // Or something similar, discussible

		public SQLDB()
		{
			if (DBContext.Hotels.Count == 0) // I'm not sure if Count exists, but something similar
			{
				CreateHotel("Initial Hotel");
			}
		}

		protected override Hotel CreateHotel(string name)
		{
			var hotel = new Hotel
			{
				ID = hotelsList.Count,
				Name = name,
				Rooms = 0u,
				Reservations = new List<Reservation>()
			};

			DBContext.Hotels.Add(hotel);

			return hotel;
		}
		protected override uint CreateRooms(Hotel hotel, uint amount)
		{
			if (hotel == null) throw new ArgumentNullException(nameof(hotel));
			
			hotel.Rooms += amount;
			DBContext.SaveChanges();

			return hotel.Rooms;
		}
		protected override Reservation CreateReservation(Hotel hotel, uint roomId, int fromDay, int toDay)
		{
			if (hotel == null) throw new ArgumentNullException(nameof(hotel));

			var reservation = new Reservation
			{
				ID = reservationsList.Count,
				RoomID = roomId,
				FromDay = fromDay,
				ToDay = toDay,
				Hotel = hotel
			};

			hotel.Reservations.Add(reservation);
			DBContext.Reservations.Add(reservation);
			DBContext.SaveChanges();

			return reservation;
		}
	}
}
