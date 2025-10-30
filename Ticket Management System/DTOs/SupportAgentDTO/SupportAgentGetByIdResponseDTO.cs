﻿using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.DTOs.SupportAgentDTO
{
    /// <summary>
    /// Represents a data transfer object (DTO) used to return detailed information 
    /// about a specific support agent, including their assigned tickets.
    /// </summary>
    public class SupportAgentGetByIdResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the support agent.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the full name of the support agent.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the specialization area of the support agent 
        /// (Example: technical support, billing, software issues)
        /// </summary>
        public string Specialization { get; set; }
        /// <summary>
        /// Gets or sets the collection of tickets assigned to the support agent.
        /// </summary>
        public ICollection<TicketInsertResponseDTO> Tickets { get; set; }
    }
}
