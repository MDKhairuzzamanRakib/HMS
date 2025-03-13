using Hms.Application.Contracts.Identity;
using Hms.Application.Models.Identity;
using Hms.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly IMediator _mediator;
        public AccountController(IAuthService authenticationService, IMediator mediator)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        [HttpPost]
        [Route("verifyToken")]
        public async Task<ActionResult<BaseCommandResponse>> VerifyToken([FromBody] VerifyTokenRequest request)
        {
            return Ok(await _authenticationService.VerifyToken(request));
        }

    }
}
