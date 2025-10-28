using Ticket_Management_System.Models.Base;

namespace Ticket_Management_System.Models
{
    public class TicketHistory : IBaseId
    {
        public int Id { get; set; }
        public string ChangeDescription { get; set; } 
        public DateTime Timestamp { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
