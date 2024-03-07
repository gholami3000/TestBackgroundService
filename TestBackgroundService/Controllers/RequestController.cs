using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBackgroundService.Service;

namespace TestBackgroundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;
        public RequestController(RequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet(Name = "Add")]
        public IActionResult Add()
        {
            _requestService.Add();
            return Ok();
        }

    }
}
