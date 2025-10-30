using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketCommentDTO;

namespace Ticket_Management_System.Controllers
{
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
