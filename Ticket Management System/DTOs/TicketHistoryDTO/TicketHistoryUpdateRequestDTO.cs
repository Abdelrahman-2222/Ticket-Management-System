namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    /// <summary>
    /// DTO used to update ticket history information.
    /// </summary>
    public class TicketHistoryUpdateRequestDTO
    {
        /// <summary>
        /// Description of the change that occurred in the ticket.
        /// </summary>
        public string ChangeDescription { get; set; }

        /// <summary>
        /// The date and time when the ticket change occurred.
        /// Default value is the current date and time.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Name of the ticket associated with this history record.
        /// </summary>
        public string TicketName { get; set; }
    }
}
