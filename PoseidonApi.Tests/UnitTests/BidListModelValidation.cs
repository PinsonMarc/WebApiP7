using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.TestHelper;
using Moq;
using PoseidonApi.Entities;
using Xunit;

namespace PoseidonApi.Tests.UnitTests
{
    public class BidListModelValidation
    {
        private BidListDTO _dto;
        private BidListValidator _validator;

        public BidListModelValidation()
        {
            //Arrange
            _dto = Mock.Of<BidListDTO>();
            _validator = new BidListValidator();
        }

        [Fact]
        public void Validate_No_Error()
        {
            _dto.Account = "Account";
            _dto.Type = "Type";

            var result = _validator.TestValidate(_dto);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_Quantity()
        {
            _dto.Account = "Account";
            _dto.Type = "Type";
            _dto.AskQuantity = -1;
            _dto.BidQuantity = -1;

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.AskQuantity).WithErrorCode("GreaterThanOrEqualValidator");
            result.ShouldHaveValidationErrorFor(x => x.BidQuantity).WithErrorCode("GreaterThanOrEqualValidator");
        }

        [Fact]
        public void Validate_Empty ()
        {
            _dto.Account = string.Empty;
            _dto.Type = string.Empty;

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Account).WithErrorCode("NotEmptyValidator");
            result.ShouldHaveValidationErrorFor(x => x.Type).WithErrorCode("NotEmptyValidator");
        }
        
        [Fact]
        public void Validate_Null ()
        {
            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Account).WithErrorCode("NotEmptyValidator");
            result.ShouldHaveValidationErrorFor(x => x.Type).WithErrorCode("NotEmptyValidator");
        }
    }
}