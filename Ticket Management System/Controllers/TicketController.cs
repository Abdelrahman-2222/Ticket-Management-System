using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// API controller for managing ticket operations.
    /// </summary>
    /// <remarks>
    /// Route: api/Ticket
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        /// <summary>
        /// Service used to handle ticket operations and persistence.
        /// </summary>
        private readonly ITicketService _ticketService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketController"/> class.
        /// </summary>
        /// <param name="ticketService">The ticket service implementation.</param>
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Creates a new ticket.
        /// </summary>
        /// <param name="ticketRequestDTO">The ticket data to create.</param>
        /// <returns>
        /// A 201 Created response containing the created <see cref="TicketInsertResponseDTO"/>, 
        /// or a 500 Internal Server Error if creation fails.
        /// </returns>
        /// <response code="201">Returns the newly created ticket.</response>
        /// <response code="500">Returned when an error occurs while creating the ticket.</response>
        /// <seealso cref="ITicketService.CreateTicketAsync(TicketInsertRequestDTO)"/>
        // POST: api/Ticket
        [HttpPost]
        public async Task<ActionResult<TicketInsertResponseDTO>> CreateTicket(TicketInsertRequestDTO ticketRequestDTO)
        {
            var createdTicket = await _ticketService.CreateTicketAsync(ticketRequestDTO);
            if (createdTicket == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating ticket.");
            }
            return CreatedAtAction(nameof(CreateTicket), new { id = createdTicket.Id }, createdTicket);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketGetIdResponseDTO>> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
        [HttpGet]
        public async Task<ActionResult<List<TicketGetIdResponseDTO>>> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            if (tickets == null || !tickets.Any())
            {
                return NotFound();
            }
            return Ok(tickets);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketUpdateResponeDTO>> UpdateTicket(int id, TicketUpdateRequestDTO ticketUpdateRequestDTO)
        {
            var updatedTicket = await _ticketService.UpdateTicketAsync(id, ticketUpdateRequestDTO);
            if (updatedTicket == null)
            {
                return NotFound();
            }
            return Ok(updatedTicket);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicket(int id)
        {
            var result = await _ticketService.DeleteTicketAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
