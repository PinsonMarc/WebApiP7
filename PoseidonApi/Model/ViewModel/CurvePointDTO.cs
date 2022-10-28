using FluentValidation;
using System;

namespace Dot.Net.PoseidonApi.Entities
{
    public class CurvePointDTO : APIEntityDTO
    {
        public int Id                { get; set; }
        public int CurveId           { get; set; }
        public DateTime? AsOfDate     { get; set; }
        public double Term           { get; set; }
        public double Value          { get; set; }  
        public DateTime? CreationDate { get; set; }
    }
    public class CurvePointValidator : AbstractValidator<CurvePointDTO>
    {
        public CurvePointValidator()
        {
            RuleFor(x => x.Value).NotNull();
            RuleFor(x => x.CurveId).NotNull();
            RuleFor(x => x.Value).NotNull();
            RuleFor(x => x.CreationDate).LessThanOrEqualTo(DateTime.Now);
        }
    }
}