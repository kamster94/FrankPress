using AutoMapper;
using FrankPress.DataAccess.Abstractions;
using FrankPress.Domain.Abstractions;
using FrankPress.Domain.DomainModels;

namespace FrankPress.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Role?> GetRole(int id)
        {
            var result = await _roleRepository.Get(id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<Role>(result);
        }
    }
}
