﻿using System;
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

namespace CargoWebApp.Controllers
{
    public class ParcelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        MapperConfiguration config;
        IMapper mapper;

        public ParcelsController()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Parcel, ParcelViewModel>();
                cfg.CreateMap<ParcelViewModel, Parcel>();
            });
            mapper = config.CreateMapper();
        }

        // GET: Parcels
        public async Task<ActionResult> Index()
        {
            return View(mapper.Map<List<Parcel>, List<ParcelViewModel>>(await db.Parcels.ToListAsync()));
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,Weight,Width,Height,Depth,Fragile,Hazardous,Perishable")] ParcelViewModel parcelViewModel)
        {
            if (ModelState.IsValid)
            {
                var parcel = mapper.Map<ParcelViewModel, Parcel>(parcelViewModel);
                parcel.Price = ParcelHelpers.CalculatePrice(parcel.Weight, parcel.Width, parcel.Depth, parcel.Height);
                db.Parcels.Add(parcel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parcelViewModel);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
