using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketHistoryDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Controller responsible for managing ticket history actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketHistoryController : BaseController
    {
        private readonly ITicketHistoryService _ticketHistoryService;

        /// <summary>
        /// Constructor to inject TicketHistory service.
        /// </summary>
        public TicketHistoryController(ITicketHistoryService ticketHistoryService)
        {
            _ticketHistoryService = ticketHistoryService;
        }

        /// <summary>
        /// Gets a specific ticket history record by id.
        /// </summary>
        /// <param name="id">Ticket history ID</param>
        /// <returns>Ticket history details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketHistoryResponseGetByIdDTO>> GetTicketHistoryById(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var ticketHistory = await _ticketHistoryService.GetTicketHistoryByIdAsync(id);
            if (ticketHistory == null)
                return NotFoundResponse("TicketHistory", id);
            return Ok(ticketHistory);
        }

        /// <summary>
        /// Gets all ticket history records.
        /// </summary>
        /// <returns>List of ticket history records</returns>
        [HttpGet]
        public async Task<ActionResult<List<TicketHistoryResponseGetByIdDTO>>> GetAllTicketHistories()
        {
            var ticketHistories = await _ticketHistoryService.GetAllTicketHistoriesAsync();
            if (ticketHistories == null || ticketHistories.Count == 0)
                return NotFound();
            return Ok(ticketHistories);
        }

        /// <summary>
        /// Updates a ticket history record by id.
        /// </summary>
        /// <param name="id">Ticket history ID</param>
        /// <param name="ticketHistoryUpdateRequestDTO">Updated ticket history data</param>
        /// <returns>Updated ticket history record</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketHistoryResponseGetByIdDTO>> UpdateTicketHistory(int id, [FromBody] TicketHistoryUpdateRequestDTO dto)
        {
            var validation = ValidateDTOWithId<TicketHistoryUpdateRequestDTO>(dto, id);
            if (validation != null) return validation;
            var updatedTicketHistory = await _ticketHistoryService.UpdateTicketHistoryAsync(id, dto);

            if (updatedTicketHistory == null)
            {
                return NotFoundResponse("TicketHistory", id);
            }

            return Ok(updatedTicketHistory);
        }

        /// <summary>
        /// Deletes a ticket history record by id.
        /// </summary>
        /// <param name="id">Ticket history ID</param>
        /// <returns>Deletion message</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicketHistory(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) return validation;
            var result = await _ticketHistoryService.DeleteTicketHistoryAsync(id);
            if (result == null)
                return NotFoundResponse("TicketHistory", id);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new ticket history record.
        /// </summary>
        /// <param name="ticketHistoryInsertRequestDTO">Ticket history creation data</param>
        /// <returns>Created ticket history record</returns>
        [HttpPost]
        public async Task<ActionResult<TicketHistoryResponseGetByIdDTO>> CreateTicketHistory(TicketHistoryInsertRequestDTO ticketHistoryInsertRequestDTO)
        {
            var validation = ValidateDTO<TicketHistoryInsertRequestDTO>(ticketHistoryInsertRequestDTO);
            if (validation != null) return validation;
            var createdTicketHistory = await _ticketHistoryService.CreateTicketHistoryAsync(ticketHistoryInsertRequestDTO);
            if (createdTicketHistory == null)
                return BadRequest();
            return CreatedAtAction(nameof(GetTicketHistoryById), new { id = createdTicketHistory.Id }, createdTicketHistory);
        }
    }
}
