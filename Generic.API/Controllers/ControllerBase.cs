using Generic.Shared.Application;
using Microsoft.AspNetCore.Mvc;

namespace Generic.API.Controllers
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public BadRequestObjectResult BadRequest<T>(ICommandResult<T> result, string title = "Bad request")
        {
            return BadRequest(new { Title = title, Details = result.FailureReasons.Select(failureReason => failureReason.Description) });
        }

        public NotFoundObjectResult NotFound<T>(ICommandResult<T> result, string title = "Not found")
        {
            return NotFound(new { Title = title, Details = result.FailureReasons.Select(failureReason => failureReason.Description) });
        }
    }
}
