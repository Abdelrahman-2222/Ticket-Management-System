using System.Threading.Tasks;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Defines the contract for managing tickets including creation, update, retrieval, and deletion.
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Retrieves a specific ticket by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket to retrieve.</param>
        /// <returns>
        /// A <see cref="TicketGetIdResponseDTO"/> representing the ticket details if found; otherwise, null.
        /// </returns>
        Task<TicketGetIdResponseDTO> GetTicketByIdAsync(int id);

        /// <summary>
        /// Creates a new ticket with the provided details.
        /// </summary>
        /// <param name="ticketRequestDTO">The ticket data required to create a new record.</param>
        /// <returns>
        /// A <see cref="TicketInsertResponseDTO"/> containing the created ticket information.
        /// </returns>
        Task<TicketInsertResponseDTO> CreateTicketAsync(TicketInsertRequestDTO ticketRequestDTO);

        /// <summary>
        /// Retrieves all tickets available in the system.
        /// </summary>
        /// <returns>
        /// A list of <see cref="TicketGetIdResponseDTO"/> objects representing all tickets.
        /// </returns>
        Task<List<TicketGetIdResponseDTO>> GetAllTicketsAsync();

        /// <summary>
        /// Updates an existing ticket using its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the ticket to update.</param>
        /// <param name="ticketUpdateRequestDTO">The updated ticket data.</param>
        /// <returns>
        /// A <see cref="TicketUpdateResponeDTO"/> containing the updated ticket information.
        /// </returns>
        Task<TicketUpdateResponeDTO> UpdateTicketAsync(int id, TicketUpdateRequestDTO ticketUpdateRequestDTO);

        /// <summary>
        /// Deletes a ticket by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket to delete.</param>
        /// <returns>
        /// A confirmation message indicating whether the delete operation was successful.
        /// </returns>
        Task<string> DeleteTicketAsync(int id);

        /// <summary>
        /// Saves pending changes to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
