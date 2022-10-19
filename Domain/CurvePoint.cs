using System;

namespace Dot.Net.WebApi.Domain
{
    public class CurvePoint
    {
        public int Id                { get; set; }
        public int CurveId           { get; set; }
        public Curve Curve           { get; set; }
        public DateTime AsOfDate     { get; set; }
        public double Term           { get; set; }
        public double Value          { get; set; }  
        public DateTime CreationDate { get; set; }
    }
}