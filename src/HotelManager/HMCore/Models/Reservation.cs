namespace HMCore.Models
{
	public class Reservation
	{
		// [Key]
		public int ID { get; set; }

		public uint RoomID { get; set; }
		public int FromDay { get; set; }
		public int ToDay { get; set; }
		
		public virtual Hotel Hotel { get; set; }
	}
}
