using AutoMapper;
using CargoWebApp.Models;
using CargoWebApp.Services;
using CargoWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace CargoWebApp.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartService cartService = new CartService();
        MapperConfiguration config;
        IMapper mapper;

        public CartsController()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
                cfg.CreateMap<Parcel, ParcelViewModel>();
            });
            mapper = config.CreateMapper();
        }

        // GET: Carts
        public ActionResult Index()
        {
            var cart = cartService.GetByUserName(User.Identity.Name);

            return View(
                mapper.Map<Cart, CartViewModel>(cart)
            );
        }

        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = cartService.GetByUserName(User.Identity.Name);

            return PartialView(
                mapper.Map<Cart, CartViewModel>(cart)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cartService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
