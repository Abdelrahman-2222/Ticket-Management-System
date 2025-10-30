namespace Ticket_Management_System.DTOs.TicketHistoryDTO
{
    /// <summary>
    /// Response DTO used to return ticket history details by history record ID.
    /// </summary>
    public class TicketHistoryResponseGetByIdDTO
    {
        /// <summary>
        /// Unique identifier of the ticket history record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the change made to the ticket.
        /// </summary>
        public string ChangeDescription { get; set; }

        /// <summary>
        /// The date and time when the change occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The name/title of the related ticket.
        /// </summary>
        public string TicketName { get; set; }
    }
}
