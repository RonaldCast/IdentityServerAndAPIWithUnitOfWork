using APITreiber.DTOs.PersonDTOs;
using FluentValidation;

namespace APITreiber.Validators.PersonValidators
{
    public class PersonValid : AbstractValidator<PersonDTO>
    {
        public PersonValid()
        {
            RuleFor(a => a.IdentityCard)
                .NotEmpty().MaximumLength(11).MinimumLength(11).WithMessage("Debe de terner 11 caracteres");
        }
    }
}