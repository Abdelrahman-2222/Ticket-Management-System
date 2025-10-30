namespace Ticket_Management_System.DTOs.SupportAgentDTO
{
    /// <summary>
    /// Represents a data transfer object (DTO) used for creating or updating 
    /// a support agent’s information.
    /// </summary>
    public class SupportAgentRequestDTO
    {
        /// <summary>
        /// Gets or sets the full name of the support agent.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sets the specialization area of the support agent.
        /// </summary>
        public string Specialization { get; set; }
    }
}
