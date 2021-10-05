using FrankPress.Domain.Abstractions;
using FrankPress.Domain.DomainModels;
using FrankPress.Domain.Requests;
using FrankPress.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrankPress.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityProviderService _identityProviderService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public UsersController(IIdentityProviderService identityProviderService, IRoleService roleService, IUserService userService)
        {
            _identityProviderService = identityProviderService;
            _roleService = roleService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var currentUserModel = await GetCurrentUserModel();
            return Ok(currentUserModel);
        }

        private async Task<User> GetCurrentUserModel()
        {
            var email = User.GetEmail();

            var identityProviderName = User.GetIdentityProvider();

            var identityProvider = await _identityProviderService.GetOrAdd(identityProviderName);

            var currentUserId = await _userService.GetCurrentUserId(identityProvider.Id, email);

            if(currentUserId != null)
            {
                return await _userService.GetCurrentUser(currentUserId.Value);
            }

            var newUser = new UserCreateRequest()
            {
                Email = email,
                Name = User.GetName(),
                LastName = User.GetLastName(),
                UserRole = await _roleService.GetRole(1),
                IdentityProvider = identityProvider
            };

            return await _userService.AddUser(newUser);
        }
    }
}
