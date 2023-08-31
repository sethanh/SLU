using DATA.EF_CORE;

namespace MAIN.Dtos.Authentications
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Name = user.Name;
            Token = token;
        }
    }
}
