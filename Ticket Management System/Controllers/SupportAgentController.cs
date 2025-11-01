using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.SupportAgentDTO;
using Ticket_Management_System.DTOs.TicketDTO;

namespace Ticket_Management_System.Controllers
{
    /// <summary>
    /// Controller responsible for handling operations related to support agents,
    /// including retrieval, creation, updating, and deletion.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SupportAgentController : BaseController
    {
        /// <summary>
        /// Service used to handle SupportAgent operations and persistence.
        /// </summary>
        private readonly ISupportAgentService _supportAgentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupportAgentController"/> class.
        /// </summary>
        /// <param name="SupportAgentService">The SupportAgent service implementation.</param>
        public SupportAgentController(ISupportAgentService supportAgentService)
        {
            _supportAgentService = supportAgentService;
        }


        /// <summary>
        /// Retrieves all support agents along with their associated tickets.
        /// </summary>
        /// <returns>
        /// A list of <see cref="SupportAgentResponseDTO"/> objects containing details of all support agents.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<SupportAgentResponseDTO>>> GetAllSupportAgents()
        {
            var supportAgents = await _supportAgentService.GetAllSupportAgentsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //if (supportAgents.)
            //    return BadRequest(ModelState);

            if (supportAgents == null)
            {
                return NotFound();
            }

            return Ok(supportAgents);
        }


        /// <summary>
        /// Retrieves a specific support agent by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent.</param>
        /// <returns>
        /// A <see cref="SupportAgentGetByIdResponseDTO"/> object containing the details of the requested support agent.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportAgentGetByIdResponseDTO>> GetSupportAgentById(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) 
                return validation;

            var supportAgent = await _supportAgentService.GetSupportAgentByIdAsync(id);

            if (supportAgent == null)
            {
                return NotFoundResponse("SupportAgent", id);
            }

            return Ok(supportAgent);
        }


        /// <summary>
        /// Creates a new support agent.
        /// </summary>
        /// <param name="supportAgentRequestDTO">The support agent data to be created.</param>
        /// <returns>
        /// A newly created <see cref="SupportAgentGetAllResponseDTO"/> object.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<SupportAgentGetAllResponseDTO>> CreateSupportAgent(SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var validation = ValidateDTO<SupportAgentRequestDTO>(supportAgentRequestDTO);
            if (validation != null) 
                return validation;

            var createdSupportAgent = await _supportAgentService.CreateSupportAgentAsync(supportAgentRequestDTO);

            if (createdSupportAgent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Support Agent.");
            }

            return CreatedAtAction(nameof(GetSupportAgentById), new { id = createdSupportAgent.Id }, createdSupportAgent);
        }



        /// <summary>
        /// Updates an existing support agent’s information.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent to update.</param>
        /// <param name="supportAgentRequestDTO">The updated support agent data.</param>
        /// <returns>
        /// The updated <see cref="SupportAgentGetAllResponseDTO"/> object.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<SupportAgentGetAllResponseDTO>> UpdateSupportAgent(int id, SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var validation = ValidateDTOWithId<SupportAgentRequestDTO>(supportAgentRequestDTO, id);
            if (validation != null) 
                return validation;

            var updatedSupportAgent = await _supportAgentService.UpdateSupportAgentAsync(id, supportAgentRequestDTO);

            if (updatedSupportAgent == null)
            {
                return NotFoundResponse("SupportAgent", id);
            }

            return Ok(updatedSupportAgent);
        }


        /// <summary>
        /// Deletes a support agent by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the support agent to delete.</param>
        /// <returns>
        /// A confirmation message indicating successful deletion.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteSupportAgent(int id)
        {
            var validation = ValidateId(id);
            if (validation != null) 
                return validation;
            var result = await _supportAgentService.DeleteSupportAgentAsync(id);

            if (result == null)
            {
                return NotFoundResponse("SupportAgent", id);
            }

            return Ok(result);
        }
    }
}
