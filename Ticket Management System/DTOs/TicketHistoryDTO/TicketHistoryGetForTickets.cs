using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    /// <summary>
    /// Represents a collection of history logs associated with a ticket.
    /// </summary>
    public class TicketHistoryGetForTickets
    {
        /// <summary>
        /// List of history entries for the ticket.
        /// </summary>
        public ICollection<TicketHistoryDTO> HistoryLogs { get; set; }
    }

    /// <summary>
    /// Represents a single ticket history log entry.
    /// </summary>
    public class TicketHistoryDTO
    {
        /// <summary>
        /// Unique identifier for the ticket history entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the change made to the ticket.
        /// </summary>
        public string ChangeDescription { get; set; }

        /// <summary>
        /// Timestamp when the change occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    }
}
