using Domain.Dto;
using Exceptions;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.ValidatorUser
{
    public class RegisterUserValidator : AbstractValidator<ModelUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage(ResourceMenssagensErro.ADICIAONAR_USER);
            RuleFor(e => e.Email).NotEmpty().WithMessage(ResourceMenssagensErro.BUSCA_ID_EMAIL);

            When(e => !string.IsNullOrWhiteSpace(e.Email), () =>
            {
                RuleFor(e => e.Email).EmailAddress().WithMessage(ResourceMenssagensErro.EMAIL_INVALIDO);
            });
            RuleFor(p => p.Password).NotEmpty().WithMessage(ResourceMenssagensErro.PASSWORD_BRANCO);

            When(p => !string.IsNullOrWhiteSpace(p.Password), () =>
            {
                RuleFor(p => p.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMenssagensErro.PASSWORD_CARACTER);
            });

            //função de validação customizada, para a propriedade Telefone
            When(p => !string.IsNullOrWhiteSpace(p.Phone), () =>
            {
                RuleFor(p => p.Phone).Custom((phone, contexto) =>
                {
                    string padraoPhone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                    var IsMatch = Regex.IsMatch(phone, padraoPhone);
                    if (IsMatch)
                    {
                        contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(phone), ResourceMenssagensErro.PHONE_INVALIDO));
                    }
                });

            });
        }
    }
}



