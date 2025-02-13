namespace Theater.Data.Models
{
	public class Ticket
	{
		public int id { get; set; }
		public Place place { get; set; }
		public TicketStatus status { get; set; }
		public int scheduleId { get; set; }
		public int price { get; set; }
	}
}
