using EmployeeManagement.Dto;
using EmployeeManagement.Validations;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementAPITest.Validators
{
    public class EmployeeUpdateValidatorTests
    {
        [Fact]
        public void EmployeeId_Should_Be_Greater_Than_Zero()
        {
            var validator =
                new EmployeeUpdateValidator();

            var dto =
                new EmployeeUpdateDto
                {
                    EmployeeId = 0
                };

            var result =
                validator.TestValidate(dto);

            result
                .ShouldHaveValidationErrorFor(
                    x => x.EmployeeId);
        }
    }
}
