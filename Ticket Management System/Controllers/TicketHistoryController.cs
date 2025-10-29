using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketHistoryDTO;

namespace Ticket_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketHistoryController : ControllerBase
    {
        private readonly ITicketHistoryService _ticketHistoryService;
        public TicketHistoryController(ITicketHistoryService ticketHistoryService)
        {
            _ticketHistoryService = ticketHistoryService;
        }
        // GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketHistoryResponseGetByIdDTO>> GetTicketHistoryById(int id)
        {
            var ticketHistory = await _ticketHistoryService.GetTicketHistoryByIdAsync(id);
            if (ticketHistory == null)
                return NotFound();
            return Ok(ticketHistory);
        }
        // GET all
        [HttpGet]
        public async Task<ActionResult<List<TicketHistoryResponseGetByIdDTO>>> GetAllTicketHistories()
        {
            var ticketHistories = await _ticketHistoryService.GetAllTicketHistoriesAsync();
            if (ticketHistories == null || ticketHistories.Count == 0)
                return NotFound();
            return Ok(ticketHistories);
        }
        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketHistoryResponseGetByIdDTO>> UpdateTicketHistory(int id, TicketHistoryUpdateRequestDTO ticketHistoryUpdateRequestDTO)
        {
            var updatedTicketHistory = await _ticketHistoryService.UpdateTicketHistoryAsync(id, ticketHistoryUpdateRequestDTO);
            if (updatedTicketHistory == null)
                return NotFound();
            return Ok(updatedTicketHistory);
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTicketHistory(int id)
        {
            var result = await _ticketHistoryService.DeleteTicketHistoryAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<TicketHistoryResponseGetByIdDTO>> CreateTicketHistory(TicketHistoryInsertRequestDTO ticketHistoryInsertRequestDTO)
        {
            var createdTicketHistory = await _ticketHistoryService.CreateTicketHistoryAsync(ticketHistoryInsertRequestDTO);
            if (createdTicketHistory == null)
                return BadRequest();
            return CreatedAtAction(nameof(GetTicketHistoryById), new { id = createdTicketHistory.Id }, createdTicketHistory);
        }   
    }
}
