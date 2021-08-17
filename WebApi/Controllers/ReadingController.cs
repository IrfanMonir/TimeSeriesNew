using Application.Readings.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
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
        [ActionName("GetAllReadingData")]
        public async Task<IActionResult> GetAllReadingData()
        {
            var result = await _mediator.Send(new ReadingList());
            //result = result.Where(i => i.ObjectId == 2).ToList();

            var query = result.Select(g => new { name = g.TimeStamp, count = g.Value }).ToList();
            // for ( )
            return Ok(query);
        }

        [HttpGet]
        [ActionName("GetReadingList")]
        public async Task<IActionResult> GetReadingList(int buildingId, int objectId,
            int dataFieldId, DateTime startTime, DateTime endTime)
        {
           var result = await _mediator.Send(new ReadingList(buildingId, objectId,
                dataFieldId, startTime, endTime));
            var query = result.Select(g => new { name = g.TimeStamp, count = g.Value }).ToList();
            return Ok(query);
        }
    }
}
