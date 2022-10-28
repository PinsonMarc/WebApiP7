using System;
namespace Dot.Net.PoseidonApi.Entities
{
    public class BidList : APIEntity
    {
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
        public DateTime? CreationDate { get; set; } = DateTime?.Now;
        public string RevisionName    { get; set; }
        public DateTime? RevisionDate  { get; set; }
        public string DealName        { get; set; }
        public string DealType        { get; set; }
        public string SourceListId    { get; set; }
        public string Side            { get; set; }            
    }
}