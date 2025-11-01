using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult ValidateModel<T>(T model)
        {
            if (model == null)
                return BadRequest($"{typeof(T).Name} data is required.");

            var result = GenericValidator.Validate(model);
            if (!result.IsValid)
                return BadRequest(result.ErrorMessage);

            return null; 
        }
    }
}
