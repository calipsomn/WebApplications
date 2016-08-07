using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoWebApp.DAL;
using CargoWebApp.Models;
using AutoMapper;
using CargoWebApp.ViewModels;
using CargoWebApp.StaticHelpers;
using Microsoft.AspNet.Identity;
using CargoWebApp.Controllers.api;
using CargoWebApp.Services;

namespace CargoWebApp.Controllers
{
    [Authorize]
    public class ParcelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly CartService cartService = new CartService();
        MapperConfiguration config;
        IMapper mapper;

        public ParcelsController()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Parcel, ParcelViewModel>();
                cfg.CreateMap<ParcelViewModel, Parcel>();
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
            });
            mapper = config.CreateMapper();
        }

        // GET: Parcels
        public async Task<ActionResult> Index()
        {
            var parcels = await db.Parcels.Where(parcel => parcel.User.UserName == User.Identity.Name).ToListAsync();
            return View(mapper.Map<List<Parcel>, List<ParcelViewModel>>(parcels));
        }

        // GET: Parcels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcel parcel = await db.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<Parcel, ParcelViewModel>(parcel));
        }

        // GET: Parcels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parcels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,Weight,Width,Height,Depth,Fragile,Hazardous,Perishable")] ParcelViewModel parcelViewModel)
        {
            if (ModelState.IsValid)
            {
                var parcel = mapper.Map<ParcelViewModel, Parcel>(parcelViewModel);
                var user = db.Users.First(u => u.UserName == User.Identity.Name);
                parcel.Price = ParcelHelpers.CalculatePrice(parcel.Weight, parcel.Width, parcel.Depth, parcel.Height);
                parcel.User = user;
                db.Parcels.Add(parcel);
                await db.SaveChangesAsync();
                var cart = cartService.GetByUserName(User.Identity.Name);
                CartItemsController cartItemsController = new CartItemsController();
                cartItemsController.Post(new CartItemViewModel
                {
                    ParcelId = parcel.Id,
                    Quantity = 1,
                    CartId = cart.Id
                });
                return RedirectToAction("Index");
            }

            return View(parcelViewModel);
        }
        
        public async Task<ActionResult> AddToCart(int id)
        {
            var parcel = await db.Parcels.FindAsync(id);
            var cart = cartService.GetByUserName(User.Identity.Name);
            CartItemsController cartItemsController = new CartItemsController();
            var cartItemViewModel = cartItemsController.Post(new CartItemViewModel
            {
                ParcelId = parcel.Id,
                Quantity = 1,
                CartId = cart.Id
            });

            return View("~/Views/Carts/Index.cshtml");
        }

        // GET: Parcels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcel parcel = await db.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<Parcel, ParcelViewModel>(parcel));
        }

        // POST: Parcels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,Weight,Width,Height,Depth,Price,Fragile,Hazardous,Perishable")] ParcelViewModel parcelVieModel)
        {
            Parcel parcel = mapper.Map<ParcelViewModel, Parcel>(parcelVieModel);
            if (ModelState.IsValid)
            {
                db.Entry(parcel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parcel);
        }

        // GET: Parcels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcel parcel = await db.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<Parcel, ParcelViewModel>(parcel));
        }

        // POST: Parcels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Parcel parcel = await db.Parcels.FindAsync(id);
            db.Parcels.Remove(parcel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public double CalculateParcelPrice(double weight, double width, double depth, double height)
        {
            return ParcelHelpers.CalculatePrice(weight, width, depth, height);
        }
    }
}
