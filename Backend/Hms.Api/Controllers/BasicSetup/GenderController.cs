using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Features.BasicSetup.Genders.Requests.Commands;
using Hms.Application.Features.BasicSetup.Genders.Requests.Queries;
using Hms.Application.Responses;
using Hms.Application;
using Hms.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Api.Controllers.BasicSetup
{
    [Route(HmsRoutePrefix.Gender)]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-Gender")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCommonBasicSetupDto Gender)
        {
            var command = new CreateGenderCommand { GenderDto = Gender };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-Gender/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CreateCommonBasicSetupDto Gender)
        {
            var command = new UpdateGenderCommand { GenderDto = Gender };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete-Gender/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteGenderCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allGender")]
        public async Task<ActionResult<List<CommonBasicSetupDto>>> Get()
        {
            var Gender = await _mediator.Send(new GetAllGenderRequest { });
            return Ok(Gender);
        }

        [HttpGet]
        [Route("get-GenderDetail/{id}")]
        public async Task<ActionResult<CommonBasicSetupDto>> Get(int id)
        {
            var Genders = await _mediator.Send(new GetGenderDetailsRequest { Id = id });
            return Ok(Genders);
        }

        [HttpGet]
        [Route("get-selectedGenders")]
        public async Task<ActionResult<List<SelectedModel>>> GetSelectedGender()
        {
            var Gender = await _mediator.Send(new GetSelectedGenderRequest { });
            return Ok(Gender);
        }

        [HttpGet]
        [Route("get-GenderLastPosition")]
        public async Task<ActionResult<int>> GetGenderLastPosition()
        {
            var Gender = await _mediator.Send(new GetGenderLastPositionRequest { });
            return Ok(Gender);
        }
    }
}