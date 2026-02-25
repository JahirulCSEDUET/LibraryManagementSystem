using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        // Injecting the logger through the constructor
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        [Route("Error/StatusCode")]
        [HttpGet]
        public IActionResult StatusCode(int statuscode)
        {
            Response.StatusCode = statuscode;
            switch (statuscode)
            {
                case 404:
                    return View("NotFound");
                case 405:
                    return View("Forbidden");
                default:
                    return View("GenericError");

            }
        }
        [Route("Error/ServerError")]
        public IActionResult ServerError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionDetails != null)
            {
                _logger.LogError(exceptionDetails.Error,
                    "An unexpected error occurred at path: {Path}. Error Message: {Message}",
                    exceptionDetails.Path,
                    exceptionDetails.Error.Message);
            }
            Response.StatusCode = 500;
            return View("ServerError");
        }

    }
}
