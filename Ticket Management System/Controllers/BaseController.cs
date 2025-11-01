using Microsoft.AspNetCore.Mvc;
using Ticket_Management_System.ValidationAbstraction;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected ActionResult? ValidateDTO<T>(T dto)
    {
        if (dto == null)
            return BadRequest($"{typeof(T).Name} data is required.");

        var result = GenericValidator.Validate(dto);
        if (!result.IsValid)
            return BadRequest(result.ErrorMessage);

        return null;
    }

    protected ActionResult? ValidateDTOWithId<T>(T dto, int id)
    {
        if (dto == null)
            return BadRequest($"{typeof(T).Name} data is required.");

        var result = GenericValidator.ValidateWithId(dto, id);
        if (!result.IsValid)
            return BadRequest(result.ErrorMessage);

        return null;
    }

    protected ActionResult? ValidateId(int id)
    {
        var result = GenericValidator.ValidateWithIdOnly(id);
        if (!result.IsValid)
            return BadRequest(result.ErrorMessage);

        return null;
    }

    protected ActionResult HandleServiceResult<T>(T? entity)
        where T : class
    {
        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    protected ActionResult HandleServiceResult(string? message)
    {
        if (string.IsNullOrEmpty(message))
            return NotFound();

        return Ok(message);
    }
}
