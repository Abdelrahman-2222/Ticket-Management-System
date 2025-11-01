using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Change Description is required.")]
        public string ChangeDescription { get; set; }

        /// <summary>
        /// Timestamp when the change occurred.
        /// </summary>
        [RequiredField("Timestamp is required.")]
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// ID of the ticket associated with the history entry.
        /// </summary>
        [RequiredField("Ticket Id is required.")]
        public int TicketId { get; set; }
    }
}
