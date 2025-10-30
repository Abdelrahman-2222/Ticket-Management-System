using Ticket_Management_System.DTOs.SupportAgentDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ISupportAgentService
    {
        /// <summary>
        /// Retrieves all support agents along with their associated tickets.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of <see cref="SupportAgentGetByIdResponseDTO"/> objects 
        /// representing all support agents and their tickets.
        /// </returns>
        Task<List<SupportAgentGetByIdResponseDTO>> GetAllSupportAgentsAsync();

        /// <summary>
        /// Retrieves a specific support agent by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="SupportAgentGetByIdResponseDTO"/> object with the support agent’s details.
        /// Returns <c>null</c> if no support agent is found with the provided ID.
        /// </returns>
        Task<SupportAgentGetByIdResponseDTO> GetSupportAgentByIdAsync(int id);

        /// <summary>
        /// Creates a new support agent record.
        /// </summary>
        /// <param name="supportAgentRequestDTO">The data transfer object containing details for the new support agent.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="SupportAgentGetByIdResponseDTO"/> object with the newly created support agent’s information.
        /// </returns>
        Task<SupportAgentGetByIdResponseDTO> CreateSupportAgentAsync(SupportAgentRequestDTO supportAgentRequestDTO);

        /// <summary>
        /// Updates an existing support agent’s information.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent to update.</param>
        /// <param name="supportAgentRequestDTO">The updated information for the support agent.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="SupportAgentGetByIdResponseDTO"/> object with the updated details of the support agent.
        /// </returns>
        Task<SupportAgentGetByIdResponseDTO> UpdateSupportAgentAsync(int id, SupportAgentRequestDTO supportAgentRequestDTO);

        /// <summary>
        /// Deletes a support agent record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a message confirming the deletion of the support agent.
        /// </returns>  
        Task<string> DeleteSupportAgentAsync(int id);

        /// <summary>
        /// Saves all pending changes to the database context asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
