using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CargoWebApp.DAL;
using CargoWebApp.Models;
using AutoMapper;
using CargoWebApp.ViewModels;
using CargoWebApp.Services;

namespace CargoWebApp.Controllers.api
{
    public class CartItemsController : ApiController
    {
        private readonly CartItemService cartItemService = new CartItemService();
        MapperConfiguration config;
        IMapper mapper;

        public CartItemsController()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
                cfg.CreateMap<Parcel, ParcelViewModel>();
                cfg.CreateMap<CartItemViewModel, CartItem>();
                cfg.CreateMap<ParcelViewModel, Parcel>();
            });
            mapper = config.CreateMapper();
        }

        public CartItemViewModel Post(CartItemViewModel cartItem)
        {
            var newCartItem = cartItemService.AddToCart(mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return mapper.Map<CartItem, CartItemViewModel>(newCartItem);
        }

        public CartItemViewModel Put(CartItemViewModel cartItem)
        {
            cartItemService.UpdateCartItem(mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return cartItem;
        }

        public CartItemViewModel Delete(CartItemViewModel cartItem)
        {
            cartItemService.DeleteCartItem(mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return cartItem;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cartItemService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}