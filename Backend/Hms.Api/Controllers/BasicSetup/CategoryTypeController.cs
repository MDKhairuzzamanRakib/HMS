using Hms.Application.Features.BasicSetup.CategoryTypes.Requests.Commands;
using Hms.Application.Features.BasicSetup.CategoryTypes.Requests.Queries;
using Hms.Application.Responses;
using Hms.Application;
using Hms.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;

namespace Hms.Api.Controllers.BasicSetup
{
    [Route(HmsRoutePrefix.CategoryType)]
    [ApiController]
    public class CategoryTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save-CategoryType")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCommonBasicSetupDto CategoryType)
        {
            var command = new CreateCategoryTypeCommand { CategoryTypeDto = CategoryType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-CategoryType/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CreateCommonBasicSetupDto CategoryType)
        {
            var command = new UpdateCategoryTypeCommand { CategoryTypeDto = CategoryType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete-CategoryType/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteCategoryTypeCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-allCategoryType")]
        public async Task<ActionResult<List<CommonBasicSetupDto>>> Get()
        {
            var CategoryType = await _mediator.Send(new GetAllCategoryTypeRequest { });
            return Ok(CategoryType);
        }

        [HttpGet]
        [Route("get-CategoryTypeDetail/{id}")]
        public async Task<ActionResult<CommonBasicSetupDto>> Get(int id)
        {
            var CategoryTypes = await _mediator.Send(new GetCategoryTypeDetailsRequest { Id = id });
            return Ok(CategoryTypes);
        }

        [HttpGet]
        [Route("get-selectedCategoryTypes")]
        public async Task<ActionResult<List<SelectedModel>>> GetSelectedCategoryType()
        {
            var CategoryType = await _mediator.Send(new GetSelectedCategoryTypeRequest { });
            return Ok(CategoryType);
        }

        [HttpGet]
        [Route("get-CategoryTypeLastPosition")]
        public async Task<ActionResult<int>> GetCategoryTypeLastPosition()
        {
            var CategoryType = await _mediator.Send(new GetCategoryTypeLastPositionRequest { });
            return Ok(CategoryType);
        }
    }
}

