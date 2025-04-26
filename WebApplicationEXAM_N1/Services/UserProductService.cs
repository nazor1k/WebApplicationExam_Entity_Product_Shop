using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Repository;

namespace WebApplicationEXAM_N1.Services
{
    public class UserProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<UserToProduct> _userToProductRepository;
        private readonly IRepository<User> _userRepository;

        public UserProductService(IRepository<Product> productRepository, IRepository<UserToProduct> userToProductRepository, IRepository<User> userRepository)
        {
            _productRepository = productRepository;
            _userToProductRepository = userToProductRepository;
            _userRepository = userRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public List<Product> GetByCondition(Func<Product, bool> predicate)
        {
            return _productRepository.GetByCondition(predicate).ToList();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(Product product, int id)
        {
            _productRepository.Update(product, id);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        
    }
}
