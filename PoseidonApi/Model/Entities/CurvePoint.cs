using System;

namespace PoseidonApi.Entities
{
    public class CurvePoint : APIEntity
    {
        public int CurveId { get; set; }
        public DateTime? AsOfDate { get; set; }
        public double Term { get; set; }
        public double Value { get; set; }
        public DateTime CreationDate { get; set; }
    }
}