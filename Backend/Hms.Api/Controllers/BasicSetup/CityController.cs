using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Features.BasicSetup.Citys.Requests.Commands;
using Hms.Application.Features.BasicSetup.Citys.Requests.Queries;
using Hms.Application.Responses;
using Hms.Application;
using Hms.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hms.Application.DTOs.BasicSetup.City;

namespace Hms.Api.Controllers.BasicSetup
{
    [Route(HmsRoutePrefix.City)]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-City")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCityDto City)
        {
            var command = new CreateCityCommand { CityDto = City };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-City/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CreateCityDto City)
        {
            var command = new UpdateCityCommand { CityDto = City };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete-City/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteCityCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allCity")]
        public async Task<ActionResult<List<CityDto>>> Get()
        {
            var City = await _mediator.Send(new GetAllCityRequest { });
            return Ok(City);
        }

        [HttpGet]
        [Route("get-CityDetail/{id}")]
        public async Task<ActionResult<CityDto>> Get(int id)
        {
            var Citys = await _mediator.Send(new GetCityDetailsRequest { Id = id });
            return Ok(Citys);
        }

        [HttpGet]
        [Route("get-selectedCitys")]
        public async Task<ActionResult<List<SelectedModel>>> GetSelectedCity(string tableName)
        {
            var City = await _mediator.Send(new GetSelectedCityRequest { });
            return Ok(City);
        }

        [HttpGet]
        [Route("get-CityLastPosition")]
        public async Task<ActionResult<int>> GetCityLastPosition()
        {
            var City = await _mediator.Send(new GetCityLastPositionRequest { });
            return Ok(City);
        }
    }
}