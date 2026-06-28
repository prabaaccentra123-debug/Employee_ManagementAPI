using EmployeeManagement.Dto;
using FluentValidation;

namespace EmployeeManagement.Validations
    
{
    public class EmployeeBaseValidator<T> :AbstractValidator<T> where T:EmployeeBaseDto
    {
        public EmployeeBaseValidator()
        {
            RuleFor(x=> x.EmployeeName).NotEmpty().MaximumLength(100);
            RuleFor(x=> x.Email).NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.Department).NotEmpty().MaximumLength(100);
            RuleFor(x => x.DateOfJoining).NotEmpty().LessThanOrEqualTo(DateTime.Today);

        }
    }
}
