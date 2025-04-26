using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationEXAM_N1.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly Context.AppContext _context;

        public UserRepository(Context.AppContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }
        public IEnumerable<User> GetByCondition(Func<User, bool> predicate)
        {
            
            return _context.Users.Include(u => u.UserData).Where(predicate).ToList();
        }
        public void Update(User newEntity, int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Name = newEntity.Name;
                user.Email = newEntity.Email;
                user.UserData.PasswordHash = newEntity.UserData.PasswordHash;
                _context.SaveChanges();
            }
        }


    }
}
