using PoseidonApi.Entities;

namespace PoseidonApi.Controllers.Domain
{
    public class Rating : APIEntity
    {
        public string MoodysRating { get; set; }
        public string SandPRating { get; set; }
        public string FitchRating { get; set; }
        public int OrderNumber { get; set; }
    }
}
