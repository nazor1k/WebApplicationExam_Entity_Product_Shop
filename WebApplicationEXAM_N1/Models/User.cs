namespace WebApplicationEXAM_N1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int UserDataId { get; set; }
        public UserData UserData { get; set; }
        public UserRole Role { get; set; }
        public List<UserToProduct> UserToProducts { get; set; }
    }

    
}
