using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using FluentValidation;

namespace EmployeeManagement.Api.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório")
            .EmailAddress().WithMessage("Formato de e-mail inválido");
        }
    }
}
