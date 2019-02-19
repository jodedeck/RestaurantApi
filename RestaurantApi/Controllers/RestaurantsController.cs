﻿using System;
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
        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }

        // GET: api/Restaurants/{name}   
        [ResponseType(typeof(Restaurant))]
        [Route("api/Restaurants/GetRestaurant/{name}")]
        public IHttpActionResult GetRestaurant(string name)
        {
            List<Restaurant> restaurants = db.Restaurants.Where(r => r.Name == name).ToList();
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