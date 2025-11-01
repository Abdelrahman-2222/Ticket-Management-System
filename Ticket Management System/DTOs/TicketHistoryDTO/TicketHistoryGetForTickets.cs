using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;
using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Description of the change made to the ticket.
        /// </summary>
        [RequiredField("Change Description is required.")]
        public string ChangeDescription { get; set; }

        /// <summary>
        /// Timestamp when the change occurred.
        /// </summary>
        [RequiredField("Timestamp is required.")]
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    }
}
