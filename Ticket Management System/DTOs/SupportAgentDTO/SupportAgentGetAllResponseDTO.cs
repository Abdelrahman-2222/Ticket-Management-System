namespace Ticket_Management_System.DTOs.SupportAgentDTO
{
    /// <summary>
    /// Represents a data transfer object (DTO) used to return basic information 
    /// about a support agent when retrieving multiple agents.
    /// </summary>
    public class SupportAgentGetAllResponseDTO
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
        /// Gets or sets the specialization area of the support agent (e.g., technical support, billing, etc.).
        /// </summary>
        public string Specialization { get; set; }
    }
}
