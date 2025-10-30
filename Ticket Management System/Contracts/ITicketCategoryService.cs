using Ticket_Management_System.DTOs.TicketCategoryDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Defines the contract for managing ticket category operations,
    /// including retrieval, creation, updating, and deletion of ticket categories.
    /// </summary>
    public interface ITicketCategoryService
    {
        /// <summary>
        /// Retrieves all ticket categories available in the system.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of <see cref="TicketCategoryResponseDTO"/> objects representing all ticket categories.
        /// </returns>
        Task<List<TicketCategoryResponseDTO>> GetAllTicketCategoryAsync();


        /// <summary>
        /// Retrieves a specific ticket category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket category.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="TicketCategoryResponseDTO"/> object with the category’s details.
        /// Returns <c>null</c> if the category is not found.
        /// </returns>
        Task<TicketCategoryResponseDTO> GetTicketCategoryByIdAsync(int id);


        /// <summary>
        /// Creates a new ticket category.
        /// </summary>
        /// <param name="ticketCategoryRequestDTO">The data transfer object containing details for the new category.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="TicketCategoryResponseDTO"/> object with the newly created category’s information.
        /// </returns>
        Task<TicketCategoryResponseDTO> CreateTicketCategoryAsync(TicketCategoryRequestDTO ticketCategoryRequestDTO);


        /// <summary>
        /// Updates an existing ticket category’s information.
        /// </summary>
        /// <param name="id">The unique identifier of the category to update.</param>
        /// <param name="ticketCategoryRequestDTO">The updated category details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="TicketCategoryResponseDTO"/> object with the updated category information.
        /// </returns>
        Task<TicketCategoryResponseDTO> UpdateTicketCategoryAsync(int id, TicketCategoryRequestDTO ticketCategoryRequestDTO);


        /// <summary>
        /// Deletes a ticket category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a message confirming that the category has been deleted.
        /// </returns>
        Task<string> DeleteTicketCategoryAsync(int id);


        /// <summary>
        /// Persists all pending changes made in the current database context asynchronously.
        /// </summary>
        Task SaveChangesAsync();
    }

}
