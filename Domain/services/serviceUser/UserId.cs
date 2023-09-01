using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Exceptions.ExceptionBase;
using Exceptions;
using Domain.services.serviceUser.InterfaceUsersServices;

namespace Domain.services.serviceUser
{
    public class UserId : IUserId
    {
        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IMapper _mapper;

        public UserId(IUserRepositoryDomain userRepositoryDomain, IMapper mapper)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
        }

        public async Task<ModelUserDto> SearchUserIdAsync(int id)
        {
            ModelUserDto user;
            try
            {
                var result = await _userRepositoryDomain.SearchUserByIdAsync(id);
                user = _mapper.Map<ModelUserDto>(result);
            }

            catch (Exception)
            {

                throw new ErroValidatorException(new List<string> { ResourceMenssagensErro.BUSCA_ID_USER });

            }
            return user;
        }
    }
}
