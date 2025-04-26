using System.Linq;
using WebApplicationEXAM_N1.Models;

namespace WebApplicationEXAM_N1.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly Context.AppContext _context;

        public ProductRepository(Context.AppContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Product> GetByCondition(Func<Product, bool> predicate)
        {
            return _context.Products.Where(predicate).ToList();
        }

        public void Update(Product newEntity, int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Title = newEntity.Title;
                product.Thumbnail = newEntity.Thumbnail;
                product.Category = newEntity.Category;
                product.Description = newEntity.Description;
                product.Rating = newEntity.Rating;
                product.Price = newEntity.Price;
                product.Quantity = newEntity.Quantity;
                _context.SaveChanges();
            }
        }
    }
}
