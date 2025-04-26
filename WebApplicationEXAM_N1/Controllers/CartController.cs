using Microsoft.AspNetCore.Mvc;
using WebApplicationEXAM_N1.Helpers;
using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Services;

namespace WebApplicationEXAM_N1.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private static readonly List<Product> products = new List<Product>();

        public CartController(CartService cartService)
        {
            _cartService = cartService;
            if (products.Count == 0)
            {
                Init();
            }
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

            //foreach (var product in products)
            //{
            //    userProductService.Add(product);
            //}
        }






        public IActionResult Index()
        {
            if (AuthorizeHelper.CurrentLogingUserToken == string.Empty)
            {
                return RedirectToAction("Index", "Authorize");
            }
            return View(_cartService.GetProductsInCart(AuthorizeHelper.CurrentLogingUserToken));
        }
        public IActionResult AddToCart(int productId)
        {
            if (AuthorizeHelper.CurrentLogingUserToken == string.Empty)
            {
                return RedirectToAction("Index", "Authorize");
            }
            if (_cartService.AddToCart(productId, 1, AuthorizeHelper.CurrentLogingUserToken))
            {
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        public IActionResult DeleteFromCart(int userToProductId)
        {
            if (AuthorizeHelper.CurrentLogingUserToken == string.Empty)
            {
                return RedirectToAction("Index", "Authorize");
            }
            if (_cartService.DeleteFromCart(AuthorizeHelper.CurrentLogingUserToken, userToProductId))
            {
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
