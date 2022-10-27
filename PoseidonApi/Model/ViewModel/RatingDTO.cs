using Dot.Net.PoseidonApi.Entities;
using FluentValidation;
using System;

namespace Dot.Net.PoseidonApi.Controllers.Domain
{
    public class RatingDTO : APIEntityDTO
    { 
        public int Id { get; set; }
        public string MoodysRating { get; set; }
        public string SandPRating { get; set; }
        public string FitchRating { get; set; }
        public int OrderNumber { get; set; }
    }
    public class RatingValidator : AbstractValidator<RatingDTO>
    {

    }
}
    