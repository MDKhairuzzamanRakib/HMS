using Hms.Application;
using Hms.Application.DTOs.Common;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.DTOs.GuestInfos;
using Hms.Application.Features.BasicSetup.Genders.Requests.Queries;
using Hms.Application.Features.GuestInfos.Requests.Commands;
using Hms.Application.Features.GuestInfos.Requests.Queries;
using Hms.Application.Models;
using Hms.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Api.Controllers.GuestInfos
{
    [Route(HmsRoutePrefix.GuestInfo)]
    [ApiController]
    public class GuestInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GuestInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-guestInfo")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGuestInfoDto guestInfoDto)
        {
            var command = new CreateGuestInfoCommand { GuestInfoDto = guestInfoDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-guestInfo/{id}")]
        public async Task<ActionResult> Put([FromBody] CreateGuestInfoDto guestInfoDto)
        {
            var command = new UpdateGuestInfoCommand { GuestInfoDto = guestInfoDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allGuestInfo")]
        public async Task<ActionResult<PagedResult<GuestInfoDto>>> Get([FromQuery] QueryParams queryParams)
        {
            var guestInfos = await _mediator.Send(new GetAllGuestInfoRequest { QueryParams = queryParams });
            return Ok(guestInfos);
        }

        [HttpGet]
        [Route("get-guestInfoDetails/{id}")]
        public async Task<ActionResult<GuestInfoDto>> GetGuestInfo(int id)
        {
            var guestInfos = await _mediator.Send(new GetGuestInfoDetailsRequest { GuestId = id });
            return Ok(guestInfos);
        }

    }
}
