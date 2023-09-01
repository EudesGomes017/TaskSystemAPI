using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.services.serviceUser.InterfaceUsersServices;
using Exceptions;
using Exceptions.ExceptionBase;

namespace Domain.services.serviceUser
{
    public class AllUsers : IAllUsers
    {

        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IMapper _mapper;

        public AllUsers(IUserRepositoryDomain userRepositoryDomain, IMapper mapper)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
        }

        public async Task<ModelUserDto[]> SearchAllUsersAsync()
        {
            ModelUserDto[] user;

            try
            {
                var result = await _userRepositoryDomain.BuscaUsersAsync();
                user = _mapper.Map<ModelUserDto[]>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (user.Length > 0)
            {
                return user;
            }

            throw new ErroValidatorException(new List<string> { ResourceMenssagensErro.LISTA_VAZIA });

        }
    }
}
