using System.ComponentModel.DataAnnotations.Schema;

namespace Theater.Data.Models
{
	public class ShopCartItem
	{
        public int id { get; set; }
        public Ticket ticket { get; set; }
        public int price { get; set; }

        [ForeignKey("ShopCartItem")]
        public string ShopCId { get; set; }
        public TicketStatus Status { get; set; }
    }
}
