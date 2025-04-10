using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Commands;
using Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Queries;
using Hms.Application.Responses;
using Hms.Application;
using Hms.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Api.Controllers.BasicSetup
{
    [Route(HmsRoutePrefix.EmployeeType)]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-EmployeeType")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCommonBasicSetupDto EmployeeType)
        {
            var command = new CreateEmployeeTypeCommand { EmployeeTypeDto = EmployeeType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-EmployeeType/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CreateCommonBasicSetupDto EmployeeType)
        {
            var command = new UpdateEmployeeTypeCommand { EmployeeTypeDto = EmployeeType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete-EmployeeType/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteEmployeeTypeCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allEmployeeType")]
        public async Task<ActionResult<List<CommonBasicSetupDto>>> Get()
        {
            var EmployeeType = await _mediator.Send(new GetAllEmployeeTypeRequest { });
            return Ok(EmployeeType);
        }

        [HttpGet]
        [Route("get-EmployeeTypeDetail/{id}")]
        public async Task<ActionResult<CommonBasicSetupDto>> Get(int id)
        {
            var EmployeeTypes = await _mediator.Send(new GetEmployeeTypeDetailsRequest { Id = id });
            return Ok(EmployeeTypes);
        }

        [HttpGet]
        [Route("get-selectedEmployeeTypes")]
        public async Task<ActionResult<List<SelectedModel>>> GetSelectedEmployeeType()
        {
            var EmployeeType = await _mediator.Send(new GetSelectedEmployeeTypeRequest { });
            return Ok(EmployeeType);
        }

        [HttpGet]
        [Route("get-EmployeeTypeLastPosition")]
        public async Task<ActionResult<int>> GetEmployeeTypeLastPosition()
        {
            var EmployeeType = await _mediator.Send(new GetEmployeeTypeLastPositionRequest { });
            return Ok(EmployeeType);
        }
    }
}