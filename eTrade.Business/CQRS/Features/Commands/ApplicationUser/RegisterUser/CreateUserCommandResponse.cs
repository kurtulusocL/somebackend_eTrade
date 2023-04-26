
namespace eTrade.Business.CQRS.Features.Commands.ApplicationUser.RegisterUser
{
    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
