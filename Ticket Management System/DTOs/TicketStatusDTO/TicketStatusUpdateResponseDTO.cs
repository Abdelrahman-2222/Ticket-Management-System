namespace Ticket_Management_System.DTOs.TicketStatusDTO
{
    /// <summary>
    /// Represents the response data transfer object for updating a ticket status.
    /// Contains both the old and new versions of the ticket status.
    /// </summary>
    public class TicketStatusUpdateResponseDTO
    {
        /// <summary>
        /// Gets or sets the previous version of the ticket status before the update.
        /// </summary>
        public TicketStatusResponseDTO OldVersion { get; set; }

        /// <summary>
        /// Gets or sets the new version of the ticket status after the update.
        /// </summary>
        public TicketStatusResponseDTO NewVersion { get; set; }
    }
}
