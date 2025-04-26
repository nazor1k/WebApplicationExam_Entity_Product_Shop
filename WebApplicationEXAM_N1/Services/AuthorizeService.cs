using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Repository;

namespace WebApplicationEXAM_N1.Services
{
    public class AuthorizeService
    {

        private readonly IRepository<User> _userRepository;

        public AuthorizeService(IRepository<User> userRepoisitoryRepository)
        {
            _userRepository = userRepoisitoryRepository;
        }

        public bool Authenticate(string login, string password)
        {
            var user = _userRepository.GetByCondition(us => us.UserData.Login == login && us.UserData.PasswordHash == password).FirstOrDefault();
            return user != null;
        }
        public string Register(User user)
        {
            var existingUser = _userRepository.GetByCondition(us => us.UserData.Login == user.UserData.Login).FirstOrDefault();
            if (existingUser != null)
            {
                return string.Empty; 
            }

            user.UserData.Token = Guid.NewGuid().ToString();
            var newUser = user;
            _userRepository.Add(newUser);
            return newUser.UserData.Token;
        }


        public string GetUserToken(string username, string password)
        {

            return _userRepository.GetByCondition(us => us.UserData.Login == username && us.UserData.PasswordHash == password).FirstOrDefault().UserData.Token;

        }
    }
}
