using System;
using System.Collections.Generic;
using System.Linq;
using HMCore.Models;

namespace HMCore.Database
{
	public class InMemoryDB : HMDatabase
	{
		private readonly List<Hotel>		hotelsList			= new List<Hotel>();
		private readonly List<Reservation>	reservationsList	= new List<Reservation>();

		protected override IQueryable<Hotel>		Hotels			=> hotelsList.AsQueryable();
		protected override IQueryable<Reservation>	Reservations	=> reservationsList.AsQueryable();

		public override Hotel DefaultHotel => hotelsList[0];

		public InMemoryDB()
		{
			CreateHotel("Initial Hotel");
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

			hotelsList.Add(hotel);

			return hotel;
		}
		protected override uint CreateRooms(Hotel hotel, uint amount)
		{
			if (hotel == null) throw new ArgumentNullException(nameof(hotel));
			
			hotel.Rooms += amount;
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
			reservationsList.Add(reservation);

			return reservation;
		}
	}
}
