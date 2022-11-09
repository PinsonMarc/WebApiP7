using Dot.Net.PoseidonApi.Entities;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Dot.Net.PoseidonApi.Controllers
{
    public class RuleDTO : APIEntityDTO
    {
        public string Name { get;set;}
        public string Description {get;set;}
        public string Json {get;set;}
        public string Template {get;set;}
        public string SqlStr {get;set;}
        public string SqlPart {get;set;}
    }

    public class RuleValidator : AbstractValidator<RuleDTO>
    {
        public RuleValidator()
        {
            RuleFor(x => x.Name).MaximumLength(256);
        }
    }
}