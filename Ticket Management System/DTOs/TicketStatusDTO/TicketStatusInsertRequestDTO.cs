namespace Ticket_Management_System.DTOs.TicketStatusDTO
{
    /// <summary>
    /// Data Transfer Object for inserting a new ticket status.
    /// </summary>
    public class TicketStatusInsertRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the ticket status.
        /// </summary>
        public string TicketStatusName { get; set; }
    }
}
