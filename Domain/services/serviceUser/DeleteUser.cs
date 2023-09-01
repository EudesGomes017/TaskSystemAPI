using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.Models;
using Domain.services.serviceUser.InterfaceUsersServices;

namespace Domain.services.serviceUser
{
    public class DeleteUser : IDeleteUser
    {


        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IMapper _mapper;

        public DeleteUser(IUserRepositoryDomain userRepositoryDomain, IMapper mapper)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAsync(ModelUserDto id)
        {
            try
            {
                var userCurrent = _mapper.Map<ModelUser>(id);
                _userRepositoryDomain.Deletar(userCurrent);

                if (await _userRepositoryDomain.SalvarMudancasAsync())
                {
                    return true;
                }

                throw new Exception("Erro ao Deletar id");
            }
            catch (Exception)
            {

                throw new Exception("Erro de servidor");
            }
        }
    }
}
