using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.Models;
using Domain.services.serviceUser.InterfaceUsersServices;
using Domain.ValidatorUser;
using Exceptions.ExceptionBase;

namespace Domain.services.serviceUser
{
    public class PostUser : IPostUser
    {
        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IMapper _mapper;

        public PostUser(IUserRepositoryDomain userRepositoryDomain, IMapper mapper)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
        }
        public async Task<object> AddUserAsync(ModelUserDto modelUser)
        {

            validator(modelUser);

            try
            {
                var result = _mapper.Map<ModelUser>(modelUser);
                result.UpdateAt = DateTime.Now;
                result.CreatedAt = DateTime.Now;
                _userRepositoryDomain.Adicionar(result);

                if (await _userRepositoryDomain.SalvarMudancasAsync())
                {
                    return result;
                }
                throw new SistemaTaskException();

            }
            catch (SistemaTaskException)
            {

                throw new SistemaTaskException();
            }

        }

        public void validator(ModelUserDto user)
        {
            var validator = new RegisterUserValidator();
            var resultado = validator.Validate(user);

            if (!resultado.IsValid)
            {
                var messageErro = resultado.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErroValidatorException(messageErro);
            }
        }
    }
}

