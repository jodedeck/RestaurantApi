﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    public class UsersController : ApiController
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // GET: 
        [ResponseType(typeof(User))]
        [Route("api/User/{userId}")]
        public IHttpActionResult GetRoleByUserId(int userId)
        {
            var user = db.Users.Find(userId);
            Role userRole = user.UserRole;

            if (user == null)
            {
                return NotFound();
            }

            return Ok(userRole);
        }

        [ResponseType(typeof(User))]
        //[HttpPost]
        [Route("api/User/Loggin/{userName}/{passWord}")]
        public IHttpActionResult GetLogged(string userName, string passWord)
        {
            var users = db.Users.ToList();

            var cryptingFactory = new CryptingFactory();
            var cryptedpw = users.Where(r => r.UserName == userName).First().Password;
            var uncryptedpw = cryptingFactory.Decrypt(cryptedpw);
            var validpw = passWord == uncryptedpw;

            //  string cryptedPassword = cryptingFactory.Encrypt(passWord);


            var validUser = users.Exists(r => r.UserName == userName && validpw);
            if (validUser) return Ok(validUser);
            else return BadRequest();

        }



        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            var cryptingFactory = new CryptingFactory();
            string cryptedPassword = cryptingFactory.Encrypt(user.Password);
            user.Password = cryptedPassword;



            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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




        // POST: api/Users
        [ResponseType(typeof(User))]

        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cryptingFactory = new CryptingFactory();
            string cryptedPassword = cryptingFactory.Encrypt(user.Password);
            user.Password = cryptedPassword;

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}