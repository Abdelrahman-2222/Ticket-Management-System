using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Controller responsible for managing ticket comments.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCommentController : ControllerBase
    {
        /// <summary>
        /// Service used to handle TicketComment operations and persistence.
        /// </summary>
        private readonly ITicketCommentsService _ticketCommentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketCommentController"/> class.
        /// </summary>
        /// <param name="ticketCommentService">The TicketComment service implementation.</param>
        public TicketCommentController(ITicketCommentsService ticketCommentService)
        {
            _ticketCommentService = ticketCommentService;
        }


        /// <summary>
        /// Retrieves all ticket comments asynchronously.
        /// </summary>
        /// <returns>
        /// A list of all <see cref="TicketCommentResponseDTO"/> objects.  
        /// Returns <see cref="NotFoundResult"/> if no comments exist.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<TicketCommentResponseDTO>>> GetAllTicketComments()
        {
            var ticketComments = await _ticketCommentService.GetAllTicketCommentAsync();

            if (ticketComments == null)
            {
                return NotFound();
            }

            return Ok(ticketComments);
        }


        /// <summary>
        /// Retrieves a specific ticket comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket comment.</param>
        /// <returns>
        /// The <see cref="TicketCommentResponseDTO"/> associated with the specified ID.  
        /// Returns <see cref="NotFoundResult"/> if the comment does not exist.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCommentResponseDTO>> GetTicketCommentById(int id)
        {
            var ticketComment = await _ticketCommentService.GetTicketCommentByIdAsync(id);

            if (ticketComment == null)
            {
                return NotFound();
            }

            return Ok(ticketComment);
        }



        /// <summary>
        /// Creates a new ticket comment.
        /// </summary>
        /// <param name="ticketCommentRequestDTO">The data transfer object containing the new comment details.</param>
        /// <returns>
        /// The created <see cref="TicketCommentResponseDTO"/> object.  
        /// Returns <see cref="BadRequestResult"/> if the creation fails.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<TicketCommentResponseDTO>> CreateTicketComment(TicketCommentRequestDTO ticketCommentRequestDTO)
        {
            var createdTicketComment = await _ticketCommentService.CreateTicketCommentAsync(ticketCommentRequestDTO);

            if (createdTicketComment == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetTicketCommentById), new { id = createdTicketComment.Id }, createdTicketComment);
        }


        /// <summary>
        /// Updates an existing ticket comment.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to update.</param>
        /// <param name="ticketCommentRequestDTO">The data transfer object containing updated comment details.</param>
        /// <returns>
        /// The updated <see cref="TicketCommentResponseDTO"/> object.  
        /// Returns <see cref="NotFoundResult"/> if the comment does not exist.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketCommentResponseDTO>> UpdateTicketComment(int id, TicketCommentRequestDTO ticketCommentRequestDTO)
        {
            var updatedTicketComment = await _ticketCommentService.UpdateTicketCommentAsync(id, ticketCommentRequestDTO);

            if (updatedTicketComment == null)
            {
                return NotFound();
            }

            return Ok(updatedTicketComment);
        }



        /// <summary>
        /// Deletes a specific ticket comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to delete.</param>
        /// <returns>
        /// Returns <see cref="NoContentResult"/> if deletion is successful.  
        /// Returns <see cref="NotFoundResult"/> if the comment does not exist.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicketComment(int id)
        {
            var result = await _ticketCommentService.DeleteTicketCommentAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Retrieves all comments associated with a specific ticket.
        /// </summary>
        /// <param name="ticketId">The unique identifier of the ticket whose comments are being retrieved.</param>
        /// <returns>
        /// A list of <see cref="TicketCommentResponseDTO"/> objects related to the specified ticket.  
        /// Returns <see cref="NotFoundResult"/> if no comments are found for the given ticket.
        /// </returns>
        [HttpGet("ticket/{ticketId}")]
        public async Task<ActionResult<List<TicketCommentResponseDTO>>> GetCommentsByTicketId(int ticketId)
        {
            var ticketComments = await _ticketCommentService.GetCommentsByTicketIdAsync(ticketId);
            if (ticketComments == null || !ticketComments.Any())
            {
                return NotFound();
            }
            return Ok(ticketComments);
        }
    }
}
