using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WS2023.Models.Entity;
using WS2023.Models.RequestModels;
using WS2023.Models.RequestModels.Events;
using WS2023.Services;

namespace WS2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private EventService eventService = new EventService();

        [HttpGet("/api/[controller]/getDataForRegistrationEvent")]
        public Task<RequestResponse> getDataForRegistrationEvent()
        {
            return eventService.getDataForRegistrationEvent();
        }

        [HttpPost("/api/[controller]/regPersonalEvent")]
        public Task<RequestResponse> personalVisit([FromBody] PersonalVisitModel personalVisit)
        {
            return eventService.RegistrationPesonalEvent(personalVisit);
        }


        [HttpPost("/api/[controller]/regGroupEvent")]
        public Task<RequestResponse> groupVisit([FromBody] GroupEvent groupEvent)
        {
            return eventService.RegistrationGroupEvent(groupEvent);
        }
    }
}
