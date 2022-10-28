using FluentValidation;
using System;

namespace Dot.Net.PoseidonApi.Entities
{
    public class TradeDTO : APIEntityDTO
    {
        public int Id { get; set; }
        public string Account {get; set;}
        public string Type {get; set;}
        public double BuyQuantity {get; set;}
        public double SellQuantity { get; set; }
        public double BuyPrice {get; set;}
        public double SellPrice {get; set;}
        public string Benchmark {get; set;}
        public DateTime? TradeDate {get; set;}
        public string Security {get; set;}
        public string Status {get; set;}
        public string Trader {get; set;}
        public string Book {get; set;}
        public string CreationName {get; set;}
        public DateTime? CreationDate {get; set;}
        public string RevisionName {get; set;}
        public DateTime? RevisionDate {get; set;}
        public string DealName {get; set;}
        public string DealType {get; set;}
        public string SourceListId {get; set;}
        public string Side {get; set;}
    }

    public class TradeValidator : AbstractValidator<TradeDTO>
    {
        public TradeValidator()
        {
            //RuleFor(x => x.SellPrice).Price
        }
    }
}