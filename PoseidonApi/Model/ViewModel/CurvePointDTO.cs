using FluentValidation;
using System;

namespace PoseidonApi.Entities
{
    public class CurvePointDTO : APIEntityDTO
    {
        public int CurveId { get; set; }
        public DateTime AsOfDate { get; set; }
        public double Term { get; set; }
        public double Value { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class CurvePointValidator : AbstractValidator<CurvePointDTO>
    {
        public CurvePointValidator()
        {
            RuleFor(x => x.CurveId).NotNull();
        }
    }
}