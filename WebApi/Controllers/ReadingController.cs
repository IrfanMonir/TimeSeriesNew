using Application.Readings.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReadingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetReadingList")]
        public async Task<IActionResult> GetReadingList(int buildingId, int objectId,
            int dataFieldId, DateTime startTime, DateTime endTime)
        {
            return Ok(await _mediator.Send(new ReadingList(buildingId, objectId,
                dataFieldId, startTime, endTime)));
        }
    }
}
