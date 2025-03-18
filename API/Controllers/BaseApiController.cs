using Application.Activities.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
                      ?? throw new InvalidOperationException("IMediator service is unavailable");

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        switch (result.IsSuccess)
        {
            case false when result.Code == 404:
                return NotFound();
            case true when result.Value != null:
                return Ok(result.Value);
            default:
                return BadRequest(result.Error);
        }
    }
}