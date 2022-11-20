using FluentValidation;

namespace PoseidonApi.Entities
{
    public class UserDTO : APIEntityDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
    }

    public class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Your username cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Your password must contain at least one symbol");
        }
    }
}