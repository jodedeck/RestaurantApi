using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FoodsController : ApiController
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: api/Foods
        public IQueryable<Food> GetFoods()
        {
            return db.Foods;
        }

        // GET: api/Foods/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult GetFood(int id)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // GET: api/Foods/5
        [ResponseType(typeof(Food))]
        [Route("api/Foods/GetDishByRestaurantId/{restaurantId}")]
        public IHttpActionResult GetDishByRestaurantId(int restaurantId)
        {
            var food = db.Foods.Where(r => r.FoodType == "Dish" && r.RestaurantId == restaurantId);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [ResponseType(typeof(Food))]
        [Route("api/Foods/GetDessertByRestaurantId/{restaurantId}")]
        public IHttpActionResult GetDessertByRestaurantId(int restaurantId)
        {
            var food = db.Foods.Where(r => r.FoodType == "Dessert" && r.RestaurantId == restaurantId);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [ResponseType(typeof(Food))]
        [Route("api/Foods/GetStarterByRestaurantId/{restaurantId}")]
        public IHttpActionResult GetStarterByRestaurantId(int restaurantId)
        {
            var food = db.Foods.Where(r => r.FoodType == "Starter" && r.RestaurantId == restaurantId);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }



        // PUT: api/Foods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFood(int id, Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food.Id)
            {
                return BadRequest();
            }

            db.Entry(food).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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

        // POST: api/Foods
        [ResponseType(typeof(Food))]
        public IHttpActionResult PostFood(Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Foods.Add(food);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = food.Id }, food);
        }

        // DELETE: api/Foods/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult DeleteFood(int id)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            db.Foods.Remove(food);
            db.SaveChanges();

            return Ok(food);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodExists(int id)
        {
            return db.Foods.Count(e => e.Id == id) > 0;
        }
    }
}