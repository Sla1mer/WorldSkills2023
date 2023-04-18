namespace WS2023.Models.RequestModels.Users
{
    public class UserAuth
    {
        public string login { get; set; }
        public string password { get; set; }

        public UserAuth()
        {

        }

        public UserAuth(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
