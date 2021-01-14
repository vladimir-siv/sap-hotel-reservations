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
			
			// By requirement, days are limited from 0 to 364 inclusive. If we don't want this
			// constraint, simply delete the following line. Or, set the Config.MaxDay to 0 or less
			// and there will not be any upper constraint.
			if (fromDay < Config.MinDay || Config.MaxDay > 0 && toDay >= Config.MaxDay) return null;

			IEnumerable<uint> availableRooms = GetAvailableRooms(hotel, fromDay, toDay);

			if (availableRooms.Count() == 0u) return null;

			Reservation leftBestFit = GetLeftBestFit(hotel, availableRooms, fromDay);
			Reservation rightBestFit = GetRightBestFit(hotel, availableRooms, toDay);

			uint i;

			if (leftBestFit == null && rightBestFit == null) i = availableRooms.First();
			else if (leftBestFit == null) i = rightBestFit.RoomID;
			else if (rightBestFit == null) i = leftBestFit.RoomID;
			else
			{
				if (fromDay - leftBestFit.ToDay <= rightBestFit.FromDay - toDay)
					i = leftBestFit.RoomID;
				else i = rightBestFit.RoomID;
			}
			
			return CreateReservation(hotel, i, fromDay, toDay);
		}

		#region Helper methods

		private IEnumerable<uint> GetAvailableRooms(Hotel hotel, int fromDay, int toDay)
		{
			var query =
				from reservation in hotel.Reservations
				where
					fromDay <= reservation.FromDay && reservation.FromDay <= toDay
					||
					fromDay <= reservation.ToDay && reservation.ToDay <= toDay
					||
					reservation.FromDay <= fromDay && fromDay <= reservation.ToDay
					||
					reservation.FromDay <= toDay && toDay <= reservation.ToDay
				select reservation.RoomID;

			IEnumerable<uint> reservedRooms = query.Distinct();

			return Enumerable.Range(0, (int)hotel.Rooms)
				.Select(i => (uint)i)
				.Except(reservedRooms);
		}
		private Reservation GetLeftBestFit(Hotel hotel, IEnumerable<uint> availableRooms, int fromDay)
		{
			var query =
				from reservation in hotel.Reservations
				where
					availableRooms.Contains(reservation.RoomID)
					&&
					reservation.ToDay < fromDay
				group reservation by reservation.RoomID into g
				select new Reservation { RoomID = g.Key, ToDay = g.Max(r => r.ToDay) };

			List<Reservation> left = query.ToList();

			Reservation min = null;

			foreach (Reservation res in left)
			{
				if (min == null || fromDay - res.ToDay < fromDay - min.ToDay)
				{
					min = res;
				}
			}

			return min;
		}
		private Reservation GetRightBestFit(Hotel hotel, IEnumerable<uint> availableRooms, int toDay)
		{
			var query =
				from reservation in hotel.Reservations
				where
					availableRooms.Contains(reservation.RoomID)
					&&
					toDay < reservation.FromDay
				group reservation by reservation.RoomID into g
				select new Reservation { RoomID = g.Key, FromDay = g.Min(r => r.FromDay) };

			List<Reservation> right = query.ToList();

			Reservation min = null;

			foreach (Reservation res in right)
			{
				if (min == null || res.FromDay - toDay < min.FromDay - toDay)
				{
					min = res;
				}
			}

			return min;
		}

		#endregion
	}
}
