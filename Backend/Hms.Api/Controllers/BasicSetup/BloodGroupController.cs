using Hms.Application;
using Hms.Application.DTOs.BasicSetup.BloodGroup;
using Hms.Application.Features.BasicSetup.BloodGroups.Requests.Commands;
using Hms.Application.Features.BasicSetup.BloodGroups.Requests.Queries;
using Hms.Application.Responses;
using Hms.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Api.Controllers.BasicSetup
{
    [Route(HmsRoutePrefix.BloodGroup)]
    [ApiController]
    public class BloodGroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BloodGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-bloodGroup")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBloodGroupDto bloodGroup)
        {
            var command = new CreateBloodGroupCommand { BloodGroupDto = bloodGroup };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-bloodGroup/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CreateBloodGroupDto bloodGroup)
        {
            var command = new UpdateBloodGroupCommand { BloodGroupDto = bloodGroup };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete-bloodGroup/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteBloodGroupCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allBloodGroup")]
        public async Task<ActionResult<List<BloodGroupDto>>> Get()
        {
            var BloodGroup = await _mediator.Send(new GetAllBloodGroupRequest { });
            return Ok(BloodGroup);
        }

        [HttpGet]
        [Route("get-bloodGroupDetail/{id}")]
        public async Task<ActionResult<BloodGroupDto>> Get(int id)
        {
            var BloodGroups = await _mediator.Send(new GetBloodGroupDetailsRequest { Id = id });
            return Ok(BloodGroups);
        }

        [HttpGet]
        [Route("get-selectedBloodGroups")]
        public async Task<ActionResult<List<SelectedModel>>> GetSelectedBloodGroup()
        {
            var bloodgroup = await _mediator.Send(new GetSelectedBloodGroupRequest { });
            return Ok(bloodgroup);
        }

        [HttpGet]
        [Route("get-bloodGroupLastPosition")]
        public async Task<ActionResult<int>> GetBloodGroupLastPosition()
        {
            var bloodgroup = await _mediator.Send(new GetBloodGroupLastPositionRequest { });
            return Ok(bloodgroup);
        }
    }
}
