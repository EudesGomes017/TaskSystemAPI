using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.Models;
using Domain.services.serviceUser.Criptorgrafia;
using Domain.services.serviceUser.InterfaceUsersServices;
using Domain.services.Token;
using Domain.Shared;
using Domain.ValidatorUser;
using Exceptions;
using Exceptions.ExceptionBase;

namespace Domain.services.serviceUser
{
    public class PostUser : IPostUser
    {

        private readonly ISearchEamil _searchEamil;
        private readonly IUserRepositoryDomain _userRepositoryDomain;
        private readonly IMapper _mapper;
        private readonly EncryptPassword _encryptPassword;
        private readonly TokenController _tokenController;

        public PostUser(IUserRepositoryDomain userRepositoryDomain, IMapper mapper, EncryptPassword encryptPassword, TokenController tokenController, ISearchEamil searchEamil)
        {
            _userRepositoryDomain = userRepositoryDomain;
            _encryptPassword = encryptPassword;
            _tokenController = tokenController;
            _mapper = mapper;
            _searchEamil = searchEamil;
        }
        public async Task<ReplyJsonRegisteredUser> AddUserAsync(ModelUserDto modelUser)
        {

            await validator(modelUser);


            try
            {
                modelUser.Password = _encryptPassword.encrypt(modelUser.Password); // senha criptografada
                var result = _mapper.Map<ModelUser>(modelUser);
                result.UpdateAt = DateTime.Now;
                _userRepositoryDomain.Adicionar(result);

                var token = _tokenController.GerarToken(result.Email);

                if (await _userRepositoryDomain.SalvarMudancasAsync())
                {
                    return new ReplyJsonRegisteredUser
                    {
                        Token = token
                    };
                }

                throw new SistemaTaskException();

            }
            catch (SistemaTaskException)
            {

                throw new SistemaTaskException();
            }

        }

        private async Task validator(ModelUserDto user)
        {
            var validator = new RegisterUserValidator();
            var resultado = validator.Validate(user);

            var existUserEmail = await _searchEamil.SearchEamil(user.Email);
            if (existUserEmail != null) 
            {
                resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceMenssagensErro.EMAIL_CADASTRADO));

            }

            if (!resultado.IsValid)
            {
                var messageErro = resultado.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErroValidatorException(messageErro);
            }
        }
    }
}

