using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketPriorityDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing ticket priorities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPriorityController : ControllerBase
    {
        private readonly ITicketPriorityService _ticketPriorityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketPriorityController"/> class.
        /// </summary>
        /// <param name="ticketPriorityService">The service used to perform ticket priority operations.</param>
        public TicketPriorityController(ITicketPriorityService ticketPriorityService)
        {
            _ticketPriorityService = ticketPriorityService;
        }

        /// <summary>
        /// Creates a new ticket priority.
        /// </summary>
        /// <param name="ticketPriorityRequestDTO">The DTO containing the data for the new ticket priority.</param>
        /// <returns>The created <see cref="TicketPriorityResponseDTO"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<TicketPriorityResponseDTO>> CreateTicketPriority(TicketPriorityRequestDTO ticketPriorityRequestDTO)
        {
            var createdTicketPriority = await _ticketPriorityService.CreateTicketPriorityAsync(ticketPriorityRequestDTO);
            if (createdTicketPriority == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Ticket Priority.");
            }

            return CreatedAtAction(nameof(CreateTicketPriority), new { id = createdTicketPriority.Id }, createdTicketPriority);
        }

        /// <summary>
        /// Retrieves a ticket priority by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority.</param>
        /// <returns>A <see cref="TicketPriorityResponseDTO"/> if found; otherwise, 404 Not Found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketPriorityResponseDTO>> GetTicketPriorityById(int id)
        {
            var ticketPriority = await _ticketPriorityService.GetTicketPriorityByIdAsync(id);
            if (ticketPriority == null)
            {
                return NotFound();
            }

            return Ok(ticketPriority);
        }

        /// <summary>
        /// Retrieves all ticket priorities.
        /// </summary>
        /// <returns>A list of <see cref="TicketPriorityResponseDTO"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<TicketPriorityResponseDTO>>> GetAllTicketPrioritys()
        {
            var ticketPrioritys = await _ticketPriorityService.GetAllTicketPrioritysAsync();
            if (ticketPrioritys == null || !ticketPrioritys.Any())
            {
                return NotFound();
            }

            return Ok(ticketPrioritys);
        }

        /// <summary>
        /// Updates an existing ticket priority.
        /// </summary>
        /// <param name="id">The id of the ticket priority to update.</param>
        /// <param name="ticketPriorityRequestDTO">The DTO containing updated ticket priority data.</param>
        /// <returns>The updated <see cref="TicketPriorityResponseDTO"/>.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketPriorityResponseDTO>> UpdateTicketPriority(int id, TicketPriorityRequestDTO ticketPriorityRequestDTO)
        {
            var updatedTicketPriority = await _ticketPriorityService.UpdateTicketPriorityAsync(id, ticketPriorityRequestDTO);
            if (updatedTicketPriority == null)
            {
                return NotFound();
            }

            return Ok(updatedTicketPriority);
        }

        /// <summary>
        /// Deletes a ticket priority by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket priority to delete.</param>
        /// <returns>A confirmation message.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicketPriority(int id)
        {
            var result = await _ticketPriorityService.DeleteTicketPriorityAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
