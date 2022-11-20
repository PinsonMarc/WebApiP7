using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.TestHelper;
using Moq;
using PoseidonApi.Entities;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class TradeModelValidation
    {
        private TradeDTO _dto;
        private TradeValidator _validator;

        public TradeModelValidation()
        {
            //Arrange
            _dto = Mock.Of<TradeDTO>();
            _validator = new TradeValidator();
        }

        [Fact]
        public void Validate_User_No_Error_Minimum()
        {

            _dto.BuyQuantity = 1;
            _dto.SellPrice = 1;
            _dto.BuyPrice = 1;
            _dto.SellQuantity = 1;

            var result = _validator.TestValidate(_dto);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_User_No_Error_All_Info()
        {

            _dto.Account = "Account";
            _dto.Type = "Type";
            _dto.Trader = "Trader";
            _dto.Book = "Book";
            _dto.CreationName = "CreationName";
            _dto.DealName = "DealName";
            _dto.DealType = "DealType";
            _dto.Side = "Side";
            _dto.SourceListId = "SourceListId";
            _dto.RevisionName = "RevisionName";
            _dto.Benchmark = "Benchmark";
            _dto.Security = "Security";
            _dto.Status = "Status";
            _dto.BuyQuantity = 1;
            _dto.SellQuantity = 1;
            _dto.BuyPrice = 1;
            _dto.SellPrice = 1;
            _dto.TradeDate = DateTime.Now;
            _dto.CreationDate = DateTime.Now;
            _dto.RevisionDate = DateTime.Now;


            var result = _validator.TestValidate(_dto);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_All_Negative ()
        {
            _dto.BuyQuantity = -1;
            _dto.SellPrice = -1;
            _dto.BuyPrice = -1;
            _dto.SellQuantity= -1;

            var result = _validator.TestValidate(_dto);
            result.ShouldHaveValidationErrorFor(x => x.BuyQuantity).WithErrorCode("GreaterThanOrEqualValidator"); 
            result.ShouldHaveValidationErrorFor(x => x.SellPrice).WithErrorCode("GreaterThanOrEqualValidator"); 
            result.ShouldHaveValidationErrorFor(x => x.SellQuantity).WithErrorCode("GreaterThanOrEqualValidator") ;
            result.ShouldHaveValidationErrorFor(x => x.BuyPrice).WithErrorCode("GreaterThanOrEqualValidator"); 
        }

        [Fact]
        public void Validate_Default ()
        {
            var result = _validator.TestValidate(_dto);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}