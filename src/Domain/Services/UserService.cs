using AutoMapper;
using FrankPress.DataAccess.Abstractions;
using FrankPress.Domain.Abstractions;
using FrankPress.Domain.DomainModels;
using FrankPress.Domain.Requests;

namespace FrankPress.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int?> GetCurrentUserId(int identityProvider, string email)
        {
            return (await _userRepository.GetByIdentityProviderAndEmail(identityProvider, email))?.Id;
        }

        public async Task<User> GetCurrentUser(int id)
        {
            var currentUser = await _userRepository.Get(id);

            if (currentUser == null)
            {
                throw new InvalidOperationException("Can't find current user in database");
            }

            return _mapper.Map<User>(currentUser);
        }

        public async Task<User> AddUser(UserCreateRequest request)
        {
            var user = DataAccess.DataModels.User.Create(
                null,
                request.Email,
                request.Name,
                request.LastName,
                $"{request.Name} {request.LastName}",
                _mapper.Map<DataAccess.DataModels.Role>(request.UserRole),
                _mapper.Map<DataAccess.DataModels.IdentityProvider>(request.IdentityProvider),
                false);

            user = await _userRepository.Save(user);

            return _mapper.Map<User>(user);
        }
    }
}
