using Ticket_Management_System.DTOs.TicketHistoryDTO;

namespace Ticket_Management_System.Contracts
{
    public interface ITicketHistoryService
    {
        /// <summary>
        /// Retrieves a specific ticket history entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket history record.</param>
        /// <returns>Ticket history details if found; otherwise null.</returns>
        Task<TicketHistoryResponseGetByIdDTO> GetTicketHistoryByIdAsync(int id);

        /// <summary>
        /// Retrieves all ticket history records.
        /// </summary>
        /// <returns>List of ticket history records.</returns>
        Task<List<TicketHistoryResponseGetByIdDTO>> GetAllTicketHistoriesAsync();

        /// <summary>
        /// Updates an existing ticket history entry.
        /// </summary>
        /// <param name="id">The ID of the ticket history to update.</param>
        /// <param name="ticketHistoryUpdateRequestDTO">The updated ticket history data.</param>
        /// <returns>The updated ticket history details.</returns>
        Task<TicketHistoryResponseGetByIdDTO> UpdateTicketHistoryAsync(int id, TicketHistoryUpdateRequestDTO ticketHistoryUpdateRequestDTO);

        /// <summary>
        /// Deletes a ticket history entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket history to delete.</param>
        /// <returns>A message indicating whether the deletion was successful.</returns>
        Task<string> DeleteTicketHistoryAsync(int id);

        /// <summary>
        /// Creates a new ticket history entry.
        /// </summary>
        /// <param name="ticketHistoryInsertRequestDTO">The data required to create the ticket history record.</param>
        /// <returns>The created ticket history details.</returns>
        Task<TicketHistoryResponseGetByIdDTO> CreateTicketHistoryAsync(TicketHistoryInsertRequestDTO ticketHistoryInsertRequestDTO);
    }
}
