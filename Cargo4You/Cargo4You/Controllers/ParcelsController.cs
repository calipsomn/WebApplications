using Cargo4You.Conversions;
using Cargo4You.DTO;
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

namespace Cargo4You.Models
{
    public class ParcelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Parcels
        public IQueryable<ParcelDTO> GetParcels()
        {
            var parcels = from parcel in db.Parcels
                          select DalToDtoConversion.GetParcelDTOFromDAL(parcel);
            return parcels;
        }

        // GET: api/Parcels/5
        [ResponseType(typeof(ParcelDTO))]
        public async Task<IHttpActionResult> GetParcel(int id)
        {
            Parcel parcel = await db.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }

            return Ok(DalToDtoConversion.GetParcelDTOFromDAL(parcel));
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
            var parcelDto = DalToDtoConversion.GetParcelDTOFromDAL(parcel);
            return CreatedAtRoute("DefaultApi", new { id = parcel.Id }, parcelDto);
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

        [ResponseType(typeof(double))]
        public async Task<IHttpActionResult> GetPrice(Parcel parcel)
        {
            return Ok(1.0);
        }
    }
}