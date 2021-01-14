using System;
using System.Collections.Generic;
using System.Linq;
using HMCore.Models;

namespace HMCore.Database
{
	public abstract class HMDatabase : IDisposable
	{
		protected abstract IQueryable<Hotel> Hotels { get; }
		protected abstract IQueryable<Reservation> Reservations { get; }

		protected abstract Hotel CreateHotel(string name);
		protected abstract uint CreateRooms(Hotel hotel, uint amount);
		protected abstract Reservation CreateReservation(Hotel hotel, uint roomId, int fromDay, int toDay);

		public abstract Hotel DefaultHotel { get; }

		public virtual void Dispose() { }

		public uint AddRoom(Hotel hotel)
		{
			return CreateRooms(hotel, 1u);
		}
		public uint AddRooms(Hotel hotel, uint amount)
		{
			return CreateRooms(hotel, amount);
		}

		public Hotel FindHotel(int id)
		{
			var query =
				from hotel in Hotels
				where hotel.ID == id
				select hotel;

			return query.First();
		}
		public Reservation FindReservation(int id)
		{
			var query =
				from reservation in Reservations
				where reservation.ID == id
				select reservation;

			return query.First();
		}

		public Reservation MakeReservation(Hotel hotel, int fromDay, int toDay)
		{
			if (hotel == null) throw new ArgumentNullException(nameof(hotel));
			if (fromDay > toDay) throw new ApplicationException("From day cannot be larger than to day when making a reservation.");
			
			var query =
				from reservation in hotel.Reservations
				where
					fromDay <= reservation.FromDay && reservation.FromDay <= toDay
					||
					fromDay <= reservation.ToDay && reservation.ToDay <= toDay
				orderby reservation.RoomID ascending
				select reservation.RoomID;

			List<uint> reservedRooms = query.ToList();

			for (uint i = 0u; i < hotel.Rooms; ++i)
			{
				if (i < reservedRooms[(int)i])
				{
					return CreateReservation(hotel, i, fromDay, toDay);
				}
			}

			return null;
		}
	}
}
