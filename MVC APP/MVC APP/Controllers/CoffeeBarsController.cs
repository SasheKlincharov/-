using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC_APP.Models;

namespace MVC_APP.Controllers
{
    public class CoffeeBarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CoffeeBars
        public IQueryable<CoffeeBar> GetBars()
        {
            return db.Bars;
        }

        // GET: api/CoffeeBars/5
        [ResponseType(typeof(CoffeeBar))]
        public IHttpActionResult GetCoffeeBar(int id)
        {
            CoffeeBar coffeeBar = db.Bars.Find(id);
            if (coffeeBar == null)
            {
                return NotFound();
            }

            return Ok(coffeeBar);
        }

        // PUT: api/CoffeeBars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoffeeBar(int id, CoffeeBar coffeeBar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coffeeBar.Id)
            {
                return BadRequest();
            }

            db.Entry(coffeeBar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeBarExists(id))
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

        // POST: api/CoffeeBars
        [ResponseType(typeof(CoffeeBar))]
        public IHttpActionResult PostCoffeeBar(CoffeeBar coffeeBar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bars.Add(coffeeBar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coffeeBar.Id }, coffeeBar);
        }

        // DELETE: api/CoffeeBars/5
        [ResponseType(typeof(CoffeeBar))]
        public IHttpActionResult DeleteCoffeeBar(int id)
        {
            CoffeeBar coffeeBar = db.Bars.Find(id);
            if (coffeeBar == null)
            {
                return NotFound();
            }

            db.Bars.Remove(coffeeBar);
            db.SaveChanges();

            return Ok(coffeeBar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoffeeBarExists(int id)
        {
            return db.Bars.Count(e => e.Id == id) > 0;
        }
    }
}