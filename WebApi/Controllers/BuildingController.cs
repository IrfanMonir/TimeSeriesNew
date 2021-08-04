using Application.Buildings.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ActionName("CreateBuilding")]
        public async Task<IActionResult> CreateBuilding(CreateBuilding command)
        {

            var result = await _mediator.Send(command);

            if (result.Succeeded)
                return StatusCode(201);

            return BadRequest(result.Errors);
        }
    }
}
