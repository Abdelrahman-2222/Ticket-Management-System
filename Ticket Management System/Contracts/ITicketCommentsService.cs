using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.Contracts
{
    /// <summary>
    /// Defines operations for managing ticket comments within the system.
    /// </summary>
    public interface ITicketCommentsService
    {
        /// <summary>
        /// Retrieves all ticket comments asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.  
        /// The task result contains a list of <see cref="TicketCommentResponseDTO"/> objects.
        /// </returns>
        Task<List<TicketCommentResponseDTO>> GetAllTicketCommentAsync();


        /// <summary>
        /// Retrieves a specific ticket comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket comment.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.  
        /// The task result contains a <see cref="TicketCommentResponseDTO"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        Task<TicketCommentResponseDTO> GetTicketCommentByIdAsync(int id);


        /// <summary>
        /// Creates a new ticket comment based on the provided data.
        /// </summary>
        /// <param name="ticketCommentRequestDTO">The data transfer object containing the new comment details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.  
        /// The task result contains the created <see cref="TicketCommentResponseDTO"/>.
        /// </returns>
        Task<TicketCommentResponseDTO> CreateTicketCommentAsync(TicketCommentRequestDTO ticketCommentRequestDTO);


        /// <summary>
        /// Updates an existing ticket comment with new details.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket comment to update.</param>
        /// <param name="ticketCommentRequestDTO">The data transfer object containing the updated comment details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.  
        /// The task result contains the updated <see cref="TicketCommentResponseDTO"/>.
        /// </returns>
        Task<TicketCommentResponseDTO> UpdateTicketCommentAsync(int id, TicketCommentRequestDTO ticketCommentRequestDTO);


        /// <summary>
        /// Deletes a ticket comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket comment to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.  
        /// The task result contains a message indicating the result of the deletion.
        /// </returns>
        Task<string> DeleteTicketCommentAsync(int id);


        /// <summary>
        /// Saves all pending changes to the data source asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }

}
