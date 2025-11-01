using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing ticket.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketController"/> class.
        /// </summary>
        /// <param name="ticketService">The service used to perform ticket operations.</param>
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Creates a new ticket.
        /// </summary>
        /// <param name="ticketRequestDTO">Ticket data to insert</param>
        /// <returns>Returns the created ticket details</returns>
        [HttpPost]
        public async Task<ActionResult<TicketInsertResponseDTO>> CreateTicket(TicketInsertRequestDTO ticketRequestDTO)
        {
            var validation = ValidateDTO(ticketRequestDTO);
            if (validation != null) return validation;
            var createdTicket = await _ticketService.CreateTicketAsync(ticketRequestDTO);
            if (createdTicket == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating ticket.");
            }
            return CreatedAtAction(nameof(CreateTicket), new { id = createdTicket.Id }, createdTicket);
        }

        /// <summary>
        /// Gets a ticket by its Id.
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <returns>Returns ticket details if found</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketGetIdResponseDTO>> GetTicketById(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;

            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFoundResponse("Ticket", id);
            }

            return Ok(ticket);
        }

        /// <summary>
        /// Gets all tickets.
        /// </summary>
        /// <returns>Returns list of all tickets</returns>
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

        /// <summary>
        /// Updates a ticket by Id.
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <param name="ticketUpdateRequestDTO">Updated ticket data</param>
        /// <returns>Returns the updated ticket</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketUpdateResponeDTO>> UpdateTicket(int id, TicketUpdateRequestDTO ticketUpdateRequestDTO)
        {
            var validation = ValidateDTOWithId<TicketUpdateRequestDTO>(ticketUpdateRequestDTO, id);
            if (validation != null) return validation;
            var updatedTicket = await _ticketService.UpdateTicketAsync(id, ticketUpdateRequestDTO);
            if (updatedTicket == null)
            {
                return NotFoundResponse("Ticket", id);
            }
            return Ok(updatedTicket);
        }

        /// <summary>
        /// Deletes a ticket by Id.
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <returns>Returns success message</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicket(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var result = await _ticketService.DeleteTicketAsync(id);
            if (result == null)
            {
                return NotFoundResponse("Ticket", id);
            }
            return Ok(result);
        }
    }
}
