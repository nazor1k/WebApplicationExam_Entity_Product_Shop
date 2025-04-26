namespace WebApplicationEXAM_N1.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public string Token { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
