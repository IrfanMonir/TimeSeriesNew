using Application.DataFields.Command;
using Application.DataFields.Query;
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
    public class DataFieldsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataFieldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ActionName("CreateDataField")]
        public async Task<IActionResult> CreateDataField(CreateDataField command)
        {

            var result = await _mediator.Send(command);

            if (result.Succeeded)
                return StatusCode(201);

            return BadRequest(result.Errors);
        }
        [HttpGet]
        [ActionName("GetDataFieldList")]
        public async Task<IActionResult> GetDataFieldList()
        {
            return Ok(await _mediator.Send(new DataFieldList()));
        }
    }
}
