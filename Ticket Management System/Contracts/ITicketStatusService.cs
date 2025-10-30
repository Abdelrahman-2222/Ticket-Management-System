using Ticket_Management_System.DTOs.TicketStatusDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Defines the contract for ticket status service operations.
    /// </summary>
    public interface ITicketStatusService
    {
        /// <summary>
        /// Retrieves a ticket status by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket status.</param>
        /// <returns>A <see cref="TicketStatusResponeMainDTO"/> representing the ticket status details.</returns>
        Task<TicketStatusResponeMainDTO> GetTicketStatusByIdAsync(int id);

        /// <summary>
        /// Creates a new ticket status.
        /// </summary>
        /// <param name="ticketStatusRequestDTO">The DTO containing the ticket status information to insert.</param>
        /// <returns>A <see cref="TicketStatusResponseDTO"/> representing the created ticket status.</returns>
        Task<TicketStatusResponseDTO> CreateTicketStatusAsync(TicketStatusInsertRequestDTO ticketStatusRequestDTO);

        /// <summary>
        /// Retrieves all ticket statuses.
        /// </summary>
        /// <returns>A list of <see cref="TicketStatusResponeMainDTO"/> representing all ticket statuses.</returns>
        Task<List<TicketStatusResponeMainDTO>> GetAllTicketStatusesAsync();

        /// <summary>
        /// Updates an existing ticket status.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket status to update.</param>
        /// <param name="ticketStatusUpdateRequestDTO">The DTO containing the updated ticket status information.</param>
        /// <returns>A <see cref="TicketStatusUpdateResponseDTO"/> containing the old and new versions of the ticket status.</returns>
        Task<TicketStatusUpdateResponseDTO> UpdateTicketStatusAsync(int id, TicketStatusInsertRequestDTO ticketStatusUpdateRequestDTO);

        /// <summary>
        /// Deletes a ticket status by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket status to delete.</param>
        /// <returns>A string message indicating the result of the deletion.</returns>
        Task<string> DeleteTicketStatusAsync(int id);

        /// <summary>
        /// Persists all changes made in the context to the underlying data store.
        /// </summary>
        /// <returns>A task representing the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}