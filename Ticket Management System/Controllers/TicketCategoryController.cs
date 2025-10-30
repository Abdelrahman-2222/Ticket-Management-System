using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.TicketCategoryDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Controller responsible for managing ticket categories.
    /// Provides endpoints for creating, reading, updating, and deleting ticket categories.
    /// </summary>
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


        /// <summary>
        /// Retrieves all ticket categories.
        /// </summary>
        /// <returns>
        /// A list of <see cref="TicketCategoryResponseDTO"/> objects if any exist;
        /// otherwise, a <see cref="NotFoundResult"/>.
        /// </returns>
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



        /// <summary>
        /// Retrieves a specific ticket category by its unique ID.
        /// </summary>
        /// <param name="id">The ID of the ticket category to retrieve.</param>
        /// <returns>
        /// A <see cref="TicketCategoryResponseDTO"/> object representing the requested category.
        /// </returns>
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



        /// <summary>
        /// Creates a new ticket category.
        /// </summary>
        /// <param name="ticketCategoryRequestDTO">The data used to create a new ticket category.</param>
        /// <returns>
        /// A newly created <see cref="TicketCategoryResponseDTO"/> object.
        /// </returns>
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



        /// <summary>
        /// Updates an existing ticket category.
        /// </summary>
        /// <param name="id">The ID of the ticket category to update.</param>
        /// <param name="ticketCategoryRequestDTO">The updated data for the ticket category.</param>
        /// <returns>
        /// The updated <see cref="TicketCategoryResponseDTO"/> object.
        /// </returns>
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



        /// <summary>
        /// Deletes a ticket category by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket category to delete.</param>
        /// <returns>A confirmation message indicating the result of the deletion.</returns>
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
