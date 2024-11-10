using marketApp.Back.Core.Application.Features.CQRS.Commands;
using marketApp.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace marketApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await this.mediator.Send(request);

            if (dto.IsExist)
                return Created("", "token oluştur");
            else
                return BadRequest("Kullanıcı adı veya şifre yanlış");
        }
    }
}