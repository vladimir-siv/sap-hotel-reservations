using System.Collections.Generic;

namespace HMCore.Models
{
	// This way our application is able to track multiple hotels if necessary.
	// If not, we can just have 1 instance of this class (e.g. 1 row in this table
	// in the database).
	public class Hotel
	{
		// [Key]
		public int ID { get; set; }

		public string Name { get; set; }
		public uint Rooms { get; set; }

		public virtual List<Reservation> Reservations { get; set; }
	}
}
