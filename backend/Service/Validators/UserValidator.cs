using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
               .NotEmpty().WithMessage("Por favor, informe um nome")
               .NotNull().WithMessage("Por favor, informe um nome.")
               .MinimumLength(1).WithMessage("Por favor, informe um nome")
               .MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracter");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Por favor, informe um email")
                .NotNull().WithMessage("Por favor, informe um email.")
                .MinimumLength(1).WithMessage("Por favor, informe um email")
                .MaximumLength(200).WithMessage("O email não pode ter mais que 100 caracter");

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("Por favor, informe um usuário")
                .NotNull().WithMessage("Por favor, informe um usuário.")
                .MinimumLength(1).WithMessage("Por favor, informe um usuário")
                .MaximumLength(100).WithMessage($"O usuário não pode ter mais que 100 caracter");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Por favor, informe um password")
                .NotNull().WithMessage("Por favor, informe um password.")
                .MinimumLength(1).WithMessage("Por favor, informe um password")
                .MaximumLength(100).WithMessage("O password não pode ter mais que 100 caracter");
        }
    }
}