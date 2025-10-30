﻿using Ticket_Management_System.DTOs.TicketDTO;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.DTOs.SupportAgentDTO
{
    /// <summary>
    /// Represents a data transfer object (DTO) used to return information 
    /// about a support agent along with their assigned tickets.
    /// </summary>
    public class SupportAgentResponseDTO
    {
        /// <summary>
        /// Gets or sets the full name of the support agent.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the specialization area of the support agent.
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets assigned to the support agent.
        /// </summary>
        public ICollection<TicketInsertResponseDTO> Tickets { get; set; }

    }
}
