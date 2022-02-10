
using Domain.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
               .NotEmpty().WithMessage("Por favor, informe um nome.")
               .NotNull().WithMessage("Por favor, informe um nome.")
               .MinimumLength(1).WithMessage("O nome deve conter mais de um caracter.")
               .MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracter.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Por favor, informe um email.")
                .NotNull().WithMessage("Por favor, informe um email.")
                .MinimumLength(6).WithMessage("Por favor, informe um email válido.")
                .MaximumLength(200).WithMessage("O email não pode ter mais que 200 caracter.")
                .EmailAddress().WithMessage("Email inválido.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Por favor, informe um password.")
                .NotNull().WithMessage("Por favor, informe um password.")
                .MinimumLength(6).WithMessage("É necessário que a senha tenha no mínimo 6 caracteres.")
                .MaximumLength(100).WithMessage("O password não pode ter mais que 100 caracter.");
        }
    }
}