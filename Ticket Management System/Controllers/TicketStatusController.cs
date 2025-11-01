using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketStatusDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Exposes CRUD endpoints for managing ticket statuses.
    /// </summary>
    /// <remarks>
    /// Routes are prefixed with 'api/TicketStatus'.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : BaseController
    {
        private readonly ITicketStatusService _ticketStatusService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketStatusController"/> class.
        /// </summary>
        /// <param name="ticketStatusService">Service that encapsulates ticket status operations.</param>
        public TicketStatusController(ITicketStatusService ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }

        /// <summary>
        /// Gets a ticket status by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket status.</param>
        /// <returns>
        /// An <see cref="ActionResult{T}"/> containing a <see cref="TicketStatusResponeMainDTO"/> when found,
        /// or <see cref="NotFoundResult"/> when no ticket status exists with the specified <paramref name="id"/>.
        /// </returns>
        /// <response code="200">Returns the ticket status.</response>
        /// <response code="404">Ticket status was not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketStatusResponeMainDTO>> GetTicketStatusById(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var ticketStatus = await _ticketStatusService.GetTicketStatusByIdAsync(id);
            if (ticketStatus == null)
                return NotFoundResponse("TicketHistory", id);
            return Ok(ticketStatus);
        }

        /// <summary>
        /// Gets all ticket statuses.
        /// </summary>
        /// <returns>
        /// An <see cref="ActionResult{T}"/> containing a list of <see cref="TicketStatusResponeMainDTO"/>.
        /// </returns>
        /// <response code="200">Returns the collection of ticket statuses.</response>
        [HttpGet]
        public async Task<ActionResult<List<TicketStatusResponeMainDTO>>> GetAllTicketStatuses()
        {
            var ticketStatuses = await _ticketStatusService.GetAllTicketStatusesAsync();
            return Ok(ticketStatuses);
        }

        /// <summary>
        /// Creates a new ticket status.
        /// </summary>
        /// <param name="ticketStatusRequestDTO">The ticket status payload to create.</param>
        /// <returns>
        /// A <see cref="CreatedAtActionResult"/> with the created <see cref="TicketStatusResponseDTO"/> and a Location header.
        /// </returns>
        /// <response code="201">Returns the newly created ticket status.</response>
        /// <response code="400">If the request body is invalid.</response>
        [HttpPost]
        public async Task<ActionResult<TicketStatusResponseDTO>> CreateTicketStatus([FromBody] TicketStatusInsertRequestDTO ticketStatusRequestDTO)
        {
            var validation = ValidateDTO<TicketStatusInsertRequestDTO>(ticketStatusRequestDTO);
            if (validation != null) return validation;
            var createdTicketStatus = await _ticketStatusService.CreateTicketStatusAsync(ticketStatusRequestDTO);
            return CreatedAtAction(nameof(GetTicketStatusById), new { id = createdTicketStatus.Id }, createdTicketStatus);
        }

        /// <summary>
        /// Updates an existing ticket status.
        /// </summary>
        /// <param name="id">The identifier of the ticket status to update.</param>
        /// <param name="ticketStatusUpdateRequestDTO">The updated ticket status payload.</param>
        /// <returns>
        /// An <see cref="ActionResult{T}"/> containing a <see cref="TicketStatusUpdateResponseDTO"/> with old and new versions,
        /// or <see cref="NotFoundResult"/> if the ticket status does not exist.
        /// </returns>
        /// <response code="200">Returns the update result including old and new versions.</response>
        /// <response code="404">Ticket status to update was not found.</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketStatusUpdateResponseDTO>> UpdateTicketStatus(int id, [FromBody] TicketStatusInsertRequestDTO ticketStatusUpdateRequestDTO)
        {
            var validation = ValidateDTOWithId<TicketStatusInsertRequestDTO>(ticketStatusUpdateRequestDTO, id);
            if (validation != null) return validation;
            var updatedTicketStatus = await _ticketStatusService.UpdateTicketStatusAsync(id, ticketStatusUpdateRequestDTO);
            if (updatedTicketStatus == null)
                return NotFoundResponse("TicketHistory", id);
            return Ok(updatedTicketStatus);
        }

        /// <summary>
        /// Deletes a ticket status.
        /// </summary>
        /// <param name="id">The identifier of the ticket status to delete.</param>
        /// <returns>
        /// An <see cref="ActionResult{T}"/> containing a confirmation message when deleted,
        /// or <see cref="NotFoundResult"/> if the ticket status does not exist.
        /// </returns>
        /// <response code="200">Ticket status was deleted successfully.</response>
        /// <response code="404">Ticket status to delete was not found.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicketStatus(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var result = await _ticketStatusService.DeleteTicketStatusAsync(id);
            if (result == null)
                return NotFoundResponse("TicketHistory", id);
            return Ok(result);
        }
    }
}