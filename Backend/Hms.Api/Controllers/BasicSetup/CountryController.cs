using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Features.BasicSetup.Countrys.Requests.Commands;
using Hms.Application.Features.BasicSetup.Countrys.Requests.Queries;
using Hms.Application.Responses;
using Hms.Application;
using Hms.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Api.Controllers.BasicSetup
{
    [Route(HmsRoutePrefix.Country)]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-Country")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCommonBasicSetupDto Country)
        {
            var command = new CreateCountryCommand { CountryDto = Country };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-Country/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CreateCommonBasicSetupDto Country)
        {
            var command = new UpdateCountryCommand { CountryDto = Country };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete-Country/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteCountryCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allCountry")]
        public async Task<ActionResult<List<CommonBasicSetupDto>>> Get()
        {
            var Country = await _mediator.Send(new GetAllCountryRequest { });
            return Ok(Country);
        }

        [HttpGet]
        [Route("get-CountryDetail/{id}")]
        public async Task<ActionResult<CommonBasicSetupDto>> Get(int id)
        {
            var Countrys = await _mediator.Send(new GetCountryDetailsRequest { Id = id });
            return Ok(Countrys);
        }

        [HttpGet]
        [Route("get-selectedCountrys")]
        public async Task<ActionResult<List<SelectedModel>>> GetSelectedCountry(string tableName)
        {
            var Country = await _mediator.Send(new GetSelectedCountryRequest { });
            return Ok(Country);
        }

        [HttpGet]
        [Route("get-CountryLastPosition")]
        public async Task<ActionResult<int>> GetCountryLastPosition()
        {
            var Country = await _mediator.Send(new GetCountryLastPositionRequest { });
            return Ok(Country);
        }
    }
}