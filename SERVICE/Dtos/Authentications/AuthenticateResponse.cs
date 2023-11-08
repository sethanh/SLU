using DATA.EF_CORE;

namespace SERVICE.Dtos.Authentications
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public static AuthenticateResponse Create(User user, string token)
        {
            return new AuthenticateResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = token,
            };
        }
    }

    public class CustomerAuthenticateResponse
    {
        public long Id { get; set; }
        public string Mobile { get; set; }
        public string Token { get; set; }


        public static CustomerAuthenticateResponse Create(CustomerAccount customerAccount, string token)
        {
            return new CustomerAuthenticateResponse
            {
                Id = customerAccount.Id,
                Mobile = customerAccount.Mobile,
                Token = token,
            };
        }
    }
}
