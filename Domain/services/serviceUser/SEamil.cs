using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.services.serviceUser.InterfaceUsersServices;

namespace Domain.services.serviceUser
{
    public class SEamil : ISearchEamil
    {

        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IMapper _mapper;

        public SEamil(IUserRepositoryDomain userRepositoryDomain, IMapper mapper)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
        }

        public async Task<ModelUserDto> SearchEamil(string email)
        {
            ModelUserDto user;

            try
            {
                var result = await _userRepositoryDomain.SearchUserByEmailAsync(email);
                user = _mapper.Map<ModelUserDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;

        }
    }
}
