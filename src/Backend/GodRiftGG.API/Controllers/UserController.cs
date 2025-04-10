using GodRiftGG.Application.Services;
using GodRiftGG.Application.UseCases.User.Register;
using GodRiftGG.Communication.Requests;
using GodRiftGG.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GodRiftGG.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            var passwordHasher = HttpContext.RequestServices.GetService<IPasswordHasher>();
            var useCase = new RegisterUserUseCase(passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher)));
            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
