using Dot.Net.PoseidonApi.Entities;

namespace Dot.Net.PoseidonApi.Controllers
{
    public class Rule : APIEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Json { get; set; }
        public string Template { get; set; }
        public string SqlStr { get; set; }
        public string SqlPart { get; set; }
    }
}