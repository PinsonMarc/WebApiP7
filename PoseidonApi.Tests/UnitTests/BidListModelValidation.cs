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
        public void ValidateNoError()
        {
            _dto.Account = "Account";
            _dto.Type = "Type";

            var result = _validator.TestValidate(_dto);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void ValidateQuantity()
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
        public void ValidateEmpty()
        {
            _dto.Account = string.Empty;
            _dto.Type = string.Empty;

            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Account).WithErrorCode("NotEmptyValidator");
            result.ShouldHaveValidationErrorFor(x => x.Type).WithErrorCode("NotEmptyValidator");
        }

        [Fact]
        public void ValidateNull()
        {
            var result = _validator.TestValidate(_dto);

            result.ShouldHaveValidationErrorFor(x => x.Account).WithErrorCode("NotEmptyValidator");
            result.ShouldHaveValidationErrorFor(x => x.Type).WithErrorCode("NotEmptyValidator");
        }
    }
}