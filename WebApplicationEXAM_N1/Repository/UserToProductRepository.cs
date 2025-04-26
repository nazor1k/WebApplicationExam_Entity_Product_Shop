using System.Linq;
using WebApplicationEXAM_N1.Models;

namespace WebApplicationEXAM_N1.Repository
{
    public class UserToProductRepository : IRepository<UserToProduct>
    {
        private readonly Context.AppContext _context;

        public UserToProductRepository(Context.AppContext context)
        {
            _context = context;
        }

        public void Add(UserToProduct entity)
        {
            _context.UserToProducts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userToProduct = _context.UserToProducts.FirstOrDefault(x => x.Id == id);
            if (userToProduct != null)
            {
                _context.UserToProducts.Remove(userToProduct);
                _context.SaveChanges();
            }
        }

        public IEnumerable<UserToProduct> GetAll()
        {
            return _context.UserToProducts.ToList();
        }

        public UserToProduct GetById(int id)
        {
            return _context.UserToProducts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<UserToProduct> GetByCondition(Func<UserToProduct, bool> predicate)
        {
            return _context.UserToProducts.Where(predicate).ToList();
        }

        public void Update(UserToProduct newEntity, int id)
        {
            var userToProduct = _context.UserToProducts.FirstOrDefault(x => x.Id == id);
            if (userToProduct != null)
            {
                userToProduct.UserId = newEntity.UserId;
                userToProduct.ProductId = newEntity.ProductId;
                _context.SaveChanges();
            }
        }
    }
}
