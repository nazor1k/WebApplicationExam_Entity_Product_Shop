using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Repository;

namespace WebApplicationEXAM_N1.Services
{
    public class CartService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<UserToProduct> _userToProductRepository;
        private readonly IRepository<User> _userRepository;

        public CartService(IRepository<Product> productRepository, IRepository<UserToProduct> userToProductRepository, IRepository<User> userRepository)
        {
            _productRepository = productRepository;
            _userToProductRepository = userToProductRepository;
            _userRepository = userRepository;
        }


        public bool AddToCart(int productId, int quantity, string userToken)
        {
            if (quantity <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(userToken))
                return false;

            var product = _productRepository.GetById(productId);
            if (product == null)
                return false;

            if (product.Quantity < quantity)
                return false;

            var userId = GetUserIdFromToken(userToken);
            if (userId == null)
                return false;

            var userToProduct = new UserToProduct
            {
                UserId = userId.Value,
                ProductId = productId,
                Quantity = quantity
            };

            product.Quantity -= quantity;
            _productRepository.Update(product, productId);

            _userToProductRepository.Add(userToProduct);
            return true;
        }

        public int? GetUserIdFromToken(string token)
        {
            return _userRepository.GetByCondition(x => x.UserData.Token == token).First().Id;
        }
        public IEnumerable<Product> GetProductsInCart(string userToken)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                return new List<Product>();

            var userId = GetUserIdFromToken(userToken);
            if (userId == null)
                return new List<Product>();

            var userProducts = _userToProductRepository.GetByCondition(x => x.UserId == userId.Value);

            var productsInCart = new List<Product>();

            foreach (var userProduct in userProducts)
            {
                var product = _productRepository.GetById(userProduct.ProductId);
                if (product != null)
                {
                   
                    var cartProduct = new Product
                    {
                        Id = userProduct.Id,
                        Title = product.Title,
                        Thumbnail = product.Thumbnail,
                        Category = product.Category,
                        Description = product.Description,
                        Rating = product.Rating,
                        Price = product.Price,
                        Quantity = userProduct.Quantity 
                    };

                    productsInCart.Add(cartProduct);
                }
            }

            return productsInCart;
        }

        public bool DeleteFromCart(string userToken, int userToProductId)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                return false;

            var userId = GetUserIdFromToken(userToken);
            if (userId == null)
                return false;

            var userProduct=_userToProductRepository.GetById(userToProductId);
            if (userProduct == null)
                return false;

            if (userProduct.UserId !=userId.Value)
                return false;

            var product = _productRepository.GetById(userProduct.ProductId ) ;
            if (product == null)
                return false;



            
            product.Quantity += userProduct.Quantity;
            _productRepository.Update(product, product.Id);

            
            _userToProductRepository.Delete(userProduct.Id);

            return true;
        }




    }
}
