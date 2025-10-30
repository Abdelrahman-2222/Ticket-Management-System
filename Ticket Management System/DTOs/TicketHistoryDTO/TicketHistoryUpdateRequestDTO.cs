using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "ChangeDescription is required.")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "ChangeDescription must be between 1 and 500 characters.")]
        public string ChangeDescription { get; set; }

        /// <summary>
        /// The date and time when the ticket change occurred.
        /// Default value is the current date and time.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        ///// <summary>
        ///// Name of the ticket associated with this history record.
        ///// </summary>
        //public int TicketID { get; set; }
    }
}
