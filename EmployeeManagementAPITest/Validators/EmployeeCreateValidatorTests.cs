using EmployeeManagement.Dto;
using EmployeeManagement.Validations;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementAPITest.Validators
{
    public class EmployeeCreateValidatorTests
    {
        private readonly EmployeeCreateValidator _validator;

        public EmployeeCreateValidatorTests()
        {
            _validator =
                new EmployeeCreateValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var dto =
                new EmployeeCreateDto
                {
                    EmployeeName = ""
                };

            var result =
                _validator.TestValidate(dto);

            result
                .ShouldHaveValidationErrorFor(
                    x => x.EmployeeName);
        }
        [Fact]
        public void Should_Have_Error_When_Email_Invalid()
        {
            var dto =
                new EmployeeCreateDto
                {
                    Email = "abc"
                };

            var result =
                _validator.TestValidate(dto);

            result
                .ShouldHaveValidationErrorFor(
                    x => x.Email);
        }
        [Fact]
        public void Should_Not_Have_Validation_Error()
        {
            var dto =
                new EmployeeCreateDto
                {
                    EmployeeName = "John",
                    Email = "john@test.com",
                    Department = "IT",
                    DateOfJoining = DateTime.Today
                };

            var result =
                _validator.TestValidate(dto);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }

}
