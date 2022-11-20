using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.TestHelper;
using Moq;
using PoseidonApi.Entities;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class UserModelValidation
    {
        private UserDTO _dto;
        private UserValidator _validator;

        public UserModelValidation()
        {
            //Arrange
            _dto = Mock.Of<UserDTO>();
            _validator = new UserValidator();
        }

        [Fact]
        public void Validate_Empty_UserName ()
        {
            _dto.UserName = "";
            _dto.Password = "Pass@word1";

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.UserName);
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Validate_PasswordTooShort()
        {
            _dto.UserName = "MyUserName";
            _dto.Password = "Pw";
            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Password).WithErrorMessage("Your password length must be at least 8.");
            result.ShouldNotHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public void Validate_Password_No_Upper_Case()
        {
            _dto.UserName = "MyUserName";
            _dto.Password = "pass@word1";

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Password).WithErrorMessage("Your password must contain at least one uppercase letter.");
        }

        [Fact]
        public void Validate_Password_No_Number()
        {
            _dto.UserName = "MyUserName";
            _dto.Password = "Pass@word";

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Password).WithErrorMessage("Your password must contain at least one number.");
        }

        [Fact]
        public void Validate_Password_No_Symbol()
        {
            _dto.UserName = "MyUserName";
            _dto.Password = "Password1";

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Password).WithErrorMessage("Your password must contain at least one symbol");
        }

        [Fact]
        public void Validate_User_No_Error()
        {
            _dto.UserName = "MyUserName";
            _dto.Password = "Pass@word1";

            var result = _validator.TestValidate(_dto);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}