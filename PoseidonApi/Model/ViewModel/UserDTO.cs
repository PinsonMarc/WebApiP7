using FluentValidation;

namespace Dot.Net.PoseidonApi.Entities
{
    public class UserDTO : APIEntityDTO
    {
        public string UserName { get; set; }
    }

    public class UserValidator : AbstractValidator<UserDTO>
    {
        public string UserName { get; set; }
    }
}