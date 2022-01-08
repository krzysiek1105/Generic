using Generic.Shared.Application;
using Microsoft.AspNetCore.Mvc;

namespace Generic.API.Controllers
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public BadRequestObjectResult BadRequest<T>(ICommandResult<T> result)
        {
            foreach (var (key, message) in result.ErrorMessages)
            {
                ModelState.AddModelError(key, message);
            }

            return BadRequest(ModelState);
        }
    }
}
