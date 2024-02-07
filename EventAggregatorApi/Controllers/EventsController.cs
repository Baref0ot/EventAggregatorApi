using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventAggregatorApi.Interfaces;

namespace EventAggregatorApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase {

        private readonly IEventBriteEventService _eventBriteService;

        public EventsController(IEventBriteEventService eventBriteService) {
            _eventBriteService = eventBriteService;
        }

       
        [HttpGet("get/categories")]
        public async Task<IActionResult> GetEventCategoriesAsync() {
            try {
                var categories = await _eventBriteService.GetEventCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex) {
                // Log exception details
                return BadRequest(ex.Message);
            }
        }// end GetEventCategories

    }// end controller
}
