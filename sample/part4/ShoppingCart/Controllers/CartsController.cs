using AutoMapper;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartService _cartService = new CartService();
        MapperConfiguration config;
        IMapper mapper;

        public CartsController()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            mapper = config.CreateMapper();
        }

        // GET: Carts
        public ActionResult Index()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session.SessionID);

            return View(
                mapper.Map<Cart, CartViewModel>(cart)
            );
        }

        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session.SessionID);

            return PartialView(
                mapper.Map<Cart, CartViewModel>(cart)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}