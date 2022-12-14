using FluentValidation;
using System;

namespace PoseidonApi.Entities
{
    public class BidListDTO : APIEntityDTO
    {
        public string Account { get; set; }
        public string Type { get; set; }
        public double AskQuantity { get; set; }
        public double BidQuantity { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public string Benchmark { get; set; }
        public DateTime? BidListDate { get; set; }
        public string Commentary { get; set; }
        public string Security { get; set; }
        public string Status { get; set; }
        public string Trader { get; set; }
        public string Book { get; set; }
        public string CreationName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string RevisionName { get; set; }
        public DateTime? RevisionDate { get; set; }
        public string DealName { get; set; }
        public string DealType { get; set; }
        public string SourceListId { get; set; }
        public string Side { get; set; }
    }

    public class BidListValidator : AbstractValidator<BidListDTO>
    {
        public BidListValidator()
        {
            RuleFor(x => x.Account).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.AskQuantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BidQuantity).GreaterThanOrEqualTo(0);
        }
    }
}