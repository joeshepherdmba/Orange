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
using Orange.Api.Models;
using Orange.Data;
using Orange.Model;

namespace Orange.Api.Controllers
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/v1/Users
        public IQueryable<User> GetApplicationUsers()
        {
            return db.Users;
        }

        // GET: api/v1/User/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetApplicationUser(string id)
        {
            User applicationUser = await db.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        // PUT: api/v1/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationUser(string id, User applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            db.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
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

        // POST: api/v1/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostApplicationUser(User applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(applicationUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationUserExists(applicationUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/v1/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteApplicationUser(string id)
        {
            User applicationUser = await db.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            db.Users.Remove(applicationUser);
            await db.SaveChangesAsync();

            return Ok(applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }

        // GET: api/v1/User/5/Items
        [ResponseType(typeof(List<MarketingItem>))]
        public async Task<IHttpActionResult> GetMarketingItems(string id)
        {
            User applicationUser = await db.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser.Items);
        }

    }
}