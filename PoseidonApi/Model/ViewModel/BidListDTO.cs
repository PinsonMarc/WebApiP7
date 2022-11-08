using FluentValidation;
using System;

namespace Dot.Net.PoseidonApi.Entities
{
    public class BidListDTO : APIEntityDTO
    {
        // TODO: Map columns in data table BIDLIST with corresponding fields
        public int Id                 { get; set; }
        public string Account         { get; set; }
        public string Type            { get; set; }
        public double AskQuantity     { get; set; }
        public double Bid             { get; set; }
        public double Ask             { get; set; }
        public string Benchmark       { get; set; }
        public DateTime? BidListDate   { get; set; }
        public string Commentary      { get; set; }
        public string Security        { get; set; }
        public string Status          { get; set; }
        public string Trader          { get; set; }
        public string Book            { get; set; }
        public string CreationName    { get; set; }
        public DateTime? CreationDate  { get; set; } = DateTime.Now;
        public string RevisionName    { get; set; }
        public DateTime? RevisionDate  { get; set; }
        public string DealName        { get; set; }
        public string DealType        { get; set; }
        public string SourceListId    { get; set; }
        public string Side            { get; set; }            
    }

    public class BidListValidator : AbstractValidator<BidListDTO>
    {
        public BidListValidator()
        {
            //RuleFor(x => x.Value).NotNull();
            //RuleFor(x => x.CurveId).NotNull();
            //RuleFor(x => x.SourceListId).NotNull();
            //RuleFor(x => x.CreationDate).LessThanOrEqualTo(DateTime?.Now);
            //RuleFor(x => x.RevisionDate).GreaterThanOrEqualTo(r => r.CreationDate ?? DateTime?.MinValue)
            //    .WithMessage("Date To must be after Date From");
        }
    }
}