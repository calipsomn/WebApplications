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
using Cargo4You.Models;

namespace Cargo4You.Controllers
{
    public class ParcelsController : ApiController
    {
        private Cargo4YouContext db = new Cargo4YouContext();

        // GET: api/Parcels
        public IQueryable<Parcel> GetParcels()
        {
            return db.Parcels;
        }

        // GET: api/Parcels/5
        [ResponseType(typeof(Parcel))]
        public async Task<IHttpActionResult> GetParcel(int id)
        {
            Parcel parcel = await db.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }

            return Ok(parcel);
        }

        // PUT: api/Parcels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParcel(int id, Parcel parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parcel.Id)
            {
                return BadRequest();
            }

            db.Entry(parcel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Parcels
        [ResponseType(typeof(Parcel))]
        public async Task<IHttpActionResult> PostParcel(Parcel parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parcels.Add(parcel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = parcel.Id }, parcel);
        }

        // DELETE: api/Parcels/5
        [ResponseType(typeof(Parcel))]
        public async Task<IHttpActionResult> DeleteParcel(int id)
        {
            Parcel parcel = await db.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }

            db.Parcels.Remove(parcel);
            await db.SaveChangesAsync();

            return Ok(parcel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParcelExists(int id)
        {
            return db.Parcels.Count(e => e.Id == id) > 0;
        }
    }
}