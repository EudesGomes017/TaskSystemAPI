using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.Models;
using Domain.services.serviceUser.InterfaceUsersServices;

namespace Domain.services.serviceUser
{
    public class UserUp : IUserUp
    {


        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IUserId _serId;
        private readonly IMapper _mapper;

        public UserUp(IUserRepositoryDomain userRepositoryDomain, IMapper mapper, IUserId serId)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
            _serId = serId;
        }

        public async Task<ModelUserDto> UpUserAsync(ModelUserDto modelUser)
        {

            try
            {
                var user = await _serId.SearchUserIdAsync(modelUser.Id);

                if (user != null)
                {
                    var result = _mapper.Map<ModelUser>(modelUser);
                    result.UpdateAt = DateTime.Now;
                    //result.CreatedAt = user.CreatedAt;

                    _userRepositoryDomain.Atualizar(result);
                    await _userRepositoryDomain.SalvarMudancasAsync();
                    return modelUser;
                }
                throw new Exception("Erro ao atualizar");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
