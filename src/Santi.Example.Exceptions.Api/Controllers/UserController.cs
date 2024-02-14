using Microsoft.AspNetCore.Mvc;
using Santi.Example.Core.Application.Interfaces;
using Santi.Example.Core.Application.ViewModels;

namespace Santi.Example.Exceptions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            userAppService = _userAppService;
        }

        [HttpPost(Name = "Create")]
        public UserViewModel Create([FromBody] CreateUserViewModel createUserViewModel)
        {
            return _userAppService.CreateWithException(createUserViewModel);
        }
    }
}