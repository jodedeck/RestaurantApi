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

    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class RestaurantsController : ApiController
    {
        private RestaurantContext db = new RestaurantContext();

        
        // GET: api/Restaurants
        [Route("Api/Restaurants/{pageNumber}-{pageSize}")]
        public IQueryable<Restaurant> GetRestaurantsByPage(int pageNumber, int pageSize)
        {
            return db.Restaurants.OrderBy(r => r.AverageRating).Skip((pageNumber - 1) * pageSize);
        }

        // GET: api/Restaurants/{name}   
        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/GetRestaurant/{name}/{pageNumber}-{pageSize}")]
        public IHttpActionResult GetRestaurantByNameByPage(string name, int pageNumber, int pageSize)
        {
            List<Restaurant> restaurants = db.Restaurants
                                             .Where(r => r.Name == name)
                                             .OrderBy(r => r.AverageRating)
                                             .Skip((pageNumber - 1) * pageSize)
                                             .ToList();

            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }


        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/GetRestaurantByText/{text}")]
        public IHttpActionResult GetRestaurantByText(string text)
        {
            List<Restaurant> restaurants = db.Restaurants.OrderByDescending(x => x.AverageRating)
                                             .Distinct()
                                             .Where(r => r.Description.Contains(text) || r.Name.Contains(text) || r.CookingType.Contains(text) || r.Address.Contains(text)).ToList();

            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }


        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/AverageRating/{RestaurantId}")]
        public IHttpActionResult GetAverageRatingByRestaurantId(int restaurantId)
        {
     
            int commentCount = db.Comments.Where(c => c.RestaurantID == restaurantId).Count();
            var comments = db.Comments.Where(c => c.RestaurantID == restaurantId).ToList();
            double sumRating = 0;
            double averageRating = 0;
            foreach (var comment in comments)
            {
                sumRating += comment.Rating;
            }
            averageRating = (int)(Math.Round(sumRating/commentCount));

            if (averageRating == 0)
            {
                return NotFound();
            }

            return Ok(averageRating);
        }


        // GET: api/Restaurants/{PageNumber}/{PageSize}   
        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetRestaurantByPage(int pageNumber, int pageSize)
        {
            List<Restaurant> restaurants = db.Restaurants.OrderByDescending(r => r.AverageRating).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }

        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/GetRestaurants/{text}/{pageNumber}-{pageSize}")]
        public IHttpActionResult GetRestaurantByTextByPage(string text, int pageNumber, int pageSize)
        {
            List<Restaurant> restaurants = db.Restaurants.OrderByDescending(x => x.AverageRating)
                                             .Distinct()
                                             .Where(r => r.Description.Contains(text) || r.Name.Contains(text) || r.CookingType.Contains(text) || r.Address.Contains(text))
                                             .OrderBy(r => r.AverageRating)
                                             .Skip((pageNumber - 1) * pageSize)
                                             .Take(pageSize).ToList();

            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }

        // GET: api/Restaurants/{CookingType}   
        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/GetRestaurantByCookingType/{cookingType}")]
        public IHttpActionResult GetRestaurantByCookingType(string cookingType)
        {
            List<Restaurant> restaurants = db.Restaurants.Where(r => r.CookingType == cookingType).ToList();

            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }


        // GET: api/Restaurants/{CookingType}   
        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/GetRestaurantByCookingType/{cookingType}/{pageNumber}-{pageSize}")]
        public IHttpActionResult GetRestaurantByCookingTypeByPage(string cookingType, int pageNumber, int pageSize)
        {
            List<Restaurant> restaurants = db.Restaurants
                                             .Where(r => r.CookingType == cookingType)
                                             .OrderBy(r => r.AverageRating)
                                             .Skip((pageNumber - 1) * pageSize)
                                             .ToList();


            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }



        // GET: api/Restaurants/5    
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/Restaurants
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }

    }
}