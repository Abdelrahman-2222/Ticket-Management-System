using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketCategoryDTO;

namespace Ticket_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoryController : ControllerBase
    {
        /// <summary>
        /// Service used to handle SupportAgent operations and persistence.
        /// </summary>
        private readonly ITicketCategoryService _ticketCategoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketCategoryController"/> class.
        /// </summary>
        /// <param name="TicketCategoryService">The TicketCategory service implementation.</param>
        public TicketCategoryController(ITicketCategoryService ticketCategoryService)
        {
            _ticketCategoryService = ticketCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTicketCategories()
        {
            var ticketCategories = await _ticketCategoryService.GetAllTicketCategoryAsync();

            if (ticketCategories == null)
            {
                return NotFound();
            }

            return Ok(ticketCategories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketCategoryById(int id)
        {
            var ticketCategory = await _ticketCategoryService.GetTicketCategoryByIdAsync(id);

            if (ticketCategory == null)
            {
                return NotFound();
            }

            return Ok(ticketCategory);
        }


        [HttpPost]
        public async Task<ActionResult> CreateTicketCategory([FromBody] TicketCategoryRequestDTO ticketCategoryRequestDTO)
        {
            var createdTicketCategory = await _ticketCategoryService.CreateTicketCategoryAsync(ticketCategoryRequestDTO);

            if(createdTicketCategory == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetTicketCategoryById), new { id = createdTicketCategory.Id }, createdTicketCategory);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTicketCategory(int id, [FromBody] TicketCategoryRequestDTO ticketCategoryRequestDTO)
        {
            var updatedTicketCategory = await _ticketCategoryService.UpdateTicketCategoryAsync(id, ticketCategoryRequestDTO);

            if (updatedTicketCategory == null)
            {
                return NotFound();
            }

            return Ok(updatedTicketCategory);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicketCategory(int id)
        {
            var result = await _ticketCategoryService.DeleteTicketCategoryAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
