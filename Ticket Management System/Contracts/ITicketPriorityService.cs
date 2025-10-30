using Ticket_Management_System.DTOs.TicketPriorityDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Defines the contract for ticket priority service operations such as creating, retrieving, updating, and deleting ticket priorities.
    /// </summary>
    public interface ITicketPriorityService
    {
        /// <summary>
        /// Creates a new ticket priority.
        /// </summary>
        /// <param name="ticketPriorityRequestDTO">The DTO containing the ticket priority data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="TicketPriorityResponseDTO"/>.</returns>
        Task<TicketPriorityResponseDTO> CreateTicketPriorityAsync(TicketPriorityRequestDTO ticketPriorityRequestDTO);

        /// <summary>
        /// Retrieves a ticket priority by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the matching <see cref="TicketPriorityResponseDTO"/> if found; otherwise, null.</returns>
        Task<TicketPriorityResponseDTO> GetTicketPriorityByIdAsync(int id);

        /// <summary>
        /// Retrieves all ticket priorities.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TicketPriorityResponseDTO"/>.</returns>
        Task<List<TicketPriorityResponseDTO>> GetAllTicketPrioritysAsync();

        /// <summary>
        /// Updates an existing ticket priority.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority to update.</param>
        /// <param name="ticketPriorityRequestDTO">The DTO containing the updated ticket priority data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="TicketPriorityResponseDTO"/>.</returns>
        Task<TicketPriorityResponseDTO> UpdateTicketPriorityAsync(int id, TicketPriorityRequestDTO ticketPriorityRequestDTO);

        /// <summary>
        /// Deletes a ticket priority by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a confirmation message.</returns>
        Task<string> DeleteTicketPriorityAsync(int id);
    }
}
