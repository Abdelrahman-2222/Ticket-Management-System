using Ticket_Management_System.ValidationAbstraction;

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
        [RequiredField("Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Description of the change made to the ticket.
        /// </summary>
        [RequiredField("Change Discription is required.")]
        public string ChangeDescription { get; set; }

        /// <summary>
        /// The date and time when the change occurred.
        /// </summary>
        [RequiredField("Time Stamp is required.")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The name/title of the related ticket.
        /// </summary>
        [RequiredField("Ticket Name is required.")]
        public string TicketName { get; set; }
    }
}
