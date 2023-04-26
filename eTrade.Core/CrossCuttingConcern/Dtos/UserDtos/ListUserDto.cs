
namespace eTrade.Core.CrossCuttingConcern.Dtos.UserDtos
{
    public class ListUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
