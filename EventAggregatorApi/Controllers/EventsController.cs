using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAggregatorApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase {

        [Route("get/allevents")]
        [HttpGet]

        public IActionResult GetAllEvents() {
            return Ok();
        }// end GetAllEvents

    }// end controller
}
