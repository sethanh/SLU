using DATA.EF_CORE;

namespace MAIN.Dtos.Authentications
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Token = token;
        }
    }
}
