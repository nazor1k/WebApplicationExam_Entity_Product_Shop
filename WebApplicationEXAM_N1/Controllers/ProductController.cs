using Microsoft.AspNetCore.Mvc;
using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Services;

namespace WebApplicationEXAM_N1.Controllers
{
    public class ProductController : Controller
    {

        private static readonly List<Product> products = new List<Product>();

        private readonly UserProductService userProductService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, UserProductService userProductService)
        {
            _logger = logger;


            //if (products.Count == 0)
            //{
            //    Init();
            //}

            this.userProductService = userProductService;
        }



        private void Init()
        {
            products.Add(new Product
            {
                
                Title = "Product 1",
                Thumbnail = "https://cached.imagescaler.hbpl.co.uk/resize/scaleWidth/743/cached.offlinehbpl.hbpl.co.uk/news/OMC/2018Winners-20180212103055980.jpg",
                Category = "Electronics",
                Description = "Description1",
                Rating = 4.5,
                Price = 99.99,
                Quantity = 10
            });

            products.Add(new Product
            {
               
                Title = "Product 2",
                Thumbnail = "https://cached.imagescaler.hbpl.co.uk/resize/scaleWidth/743/cached.offlinehbpl.hbpl.co.uk/news/OMC/2018Winners-20180212103055980.jpg",
                Category = "Books",
                Description = "Description2",
                Rating = 4.2,
                Price = 19.99,
                Quantity = 25
            });

            products.Add(new Product
            {
                
                Title = "Product 3",
                Thumbnail = "https://cached.imagescaler.hbpl.co.uk/resize/scaleWidth/743/cached.offlinehbpl.hbpl.co.uk/news/OMC/2018Winners-20180212103055980.jpg",
                Category = "Clothing",
                Description = "Description3",
                Rating = 4.0,
                Price = 49.99,
                Quantity = 15
            });

            products.Add(new Product
            {
                
                Title = "Product 4",
                Thumbnail = "https://cached.imagescaler.hbpl.co.uk/resize/scaleWidth/743/cached.offlinehbpl.hbpl.co.uk/news/OMC/2018Winners-20180212103055980.jpg",
                Category = "Home",
                Description = "Description4",
                Rating = 4.7,
                Price = 29.99,
                Quantity = 8
            });

            products.Add(new Product
            {
                
                Title = "Product 5",
                Thumbnail = "https://cached.imagescaler.hbpl.co.uk/resize/scaleWidth/743/cached.offlinehbpl.hbpl.co.uk/news/OMC/2018Winners-20180212103055980.jpg",
                Category = "Toys",
                Description = "Description5",
                Rating = 4.8,
                Price = 24.99,
                Quantity = 30
            });

            foreach (var product in products)
            {
                userProductService.Add(product);
            }
        }


        public IActionResult Index()
        {
            //Init();
            return View(userProductService.GetAll());
        }

        public IActionResult GetProduct(string searchBy, string value)
        {
            var allProducts = new List<Product>();
            switch (searchBy)
            {
                case "title":
                    allProducts = userProductService.GetByCondition(p => p.Title == value);
                    break;
                case "price":
                    if (double.TryParse(value, out double price))
                    {
                        allProducts = userProductService.GetByCondition(p => p.Price == price);
                    }
                    break;
                case "rating":
                    if (double.TryParse(value, out double rating))
                    {
                        allProducts = userProductService.GetByCondition(p => p.Rating == rating);
                    }
                    break;
                default:
                    allProducts = userProductService.GetAll();
                    break;

            }


            return View("Index", allProducts);
        }
    }
}
