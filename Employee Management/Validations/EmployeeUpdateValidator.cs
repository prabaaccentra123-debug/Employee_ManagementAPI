using EmployeeManagement.Dto;
using FluentValidation;

namespace EmployeeManagement.Validations
{
    public class EmployeeUpdateValidator:EmployeeBaseValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(x=> x.EmployeeId).NotEmpty().GreaterThan(0);
        }
    }
}
