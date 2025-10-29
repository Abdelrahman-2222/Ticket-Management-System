using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.DTOs.SupportAgentDTO;

namespace Ticket_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportAgentController : ControllerBase
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


        [HttpGet]
        public async Task<ActionResult<List<SupportAgentResponseDTO>>> GetAllSupportAgents()
        {
            var supportAgents = await _supportAgentService.GetAllSupportAgentsAsync();

            if (supportAgents == null)
            {
                return NotFound();
            }

            return Ok(supportAgents);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SupportAgentGetByIdResponseDTO>> GetSupportAgentById(int id)
        {
            var supportAgent = await _supportAgentService.GetSupportAgentByIdAsync(id);

            if (supportAgent == null)
            {
                return NotFound();
            }

            return Ok(supportAgent);
        }


        [HttpPost]
        public async Task<ActionResult<SupportAgentGetAllResponseDTO>> CreateSupportAgent(SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var createdSupportAgent = await _supportAgentService.CreateSupportAgentAsync(supportAgentRequestDTO);

            return CreatedAtAction(nameof(GetSupportAgentById), new { id = createdSupportAgent.Id }, createdSupportAgent);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<SupportAgentGetAllResponseDTO>> UpdateSupportAgent(int id, SupportAgentRequestDTO supportAgentRequestDTO)
        {
            var updatedSupportAgent = await _supportAgentService.UpdateSupportAgentAsync(id, supportAgentRequestDTO);

            if (updatedSupportAgent == null)
            {
                return NotFound();
            }

            return Ok(updatedSupportAgent);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteSupportAgent(int id)
        {
            var result = await _supportAgentService.DeleteSupportAgentAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
