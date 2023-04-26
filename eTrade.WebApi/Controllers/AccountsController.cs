using eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.FacebookLogin;
using eTrade.Business.CQRS.Features.Commands.ApplicationUser.ExternalLogins.GoogleLogin;
using eTrade.Business.CQRS.Features.Commands.ApplicationUser.LoginUser;
using eTrade.Business.CQRS.Features.Commands.ApplicationUser.RefreshTokenLogin;
using eTrade.Business.CQRS.Features.Commands.ApplicationUser.RegisterUser;
using eTrade.Business.CQRS.Features.Commands.ApplicationUser.ResetPassword;
using eTrade.Business.CQRS.Features.Commands.ApplicationUser.ResetTokenVerify;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eTrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("facebook-login")]
        public async Task<IActionResult> FacebookLogin(FacebookLoginCommandRequest facebookLoginCommandRequest)
        {
            FacebookLoginCommandResponse response = await _mediator.Send(facebookLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }

        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody] ResetTokenVerifyCommandRequest ResetTokenverifyCommandRequest)
        {
            ResetTokenVerifyCommandResponse response = await _mediator.Send(ResetTokenverifyCommandRequest);
            return Ok(response);
        }
    }
}
