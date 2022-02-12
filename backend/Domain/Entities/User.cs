using CrossCutting.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string ?Name { get; private set; }
        public string  ?Email  { get; private set; }
        public string ?Password {get; private set;}

        protected User(){} //entityframework

        public User(string? name, string? email, string? password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var Validation = validator.Validate(this);
            if (! Validation.IsValid)
            {
                foreach (var error in Validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new DomainException("Ocorreu um erro.", _errors);
            }

            return true;
        }
    }
}