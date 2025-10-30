namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    /// <summary>
    /// DTO used to insert a new ticket history record.
    /// </summary>
    public class TicketHistoryInsertRequestDTO
    {
        /// <summary>
        /// Description of the change made to the ticket.
        /// </summary>
        public string ChangeDescription { get; set; }

        /// <summary>
        /// Timestamp when the change occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// ID of the ticket associated with the history entry.
        /// </summary>
        public int TicketId { get; set; }
    }
}
