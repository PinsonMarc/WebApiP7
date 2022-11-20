using FluentValidation;
using PoseidonApi.Entities;

namespace PoseidonApi.Controllers.Domain
{
    public class RatingDTO : APIEntityDTO
    {
        public string MoodysRating { get; set; }
        public string SandPRating { get; set; }
        public string FitchRating { get; set; }
        public int OrderNumber { get; set; }
    }
    public class RatingValidator : AbstractValidator<RatingDTO>
    {
        public RatingValidator()
        {
            RuleFor(x => x.OrderNumber).GreaterThanOrEqualTo(0);
        }
    }
}
