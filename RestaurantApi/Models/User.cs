using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class User
    {
        public int    Id { get; set; }
        public string FirstName { get; set; }
        public Role   UserRole { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    // visitor : pas connecté, user : normal, admin : tout pouvoir, owner :  propriétaire d'un restaurant 
    public enum Role { visitor, user, admin, owner};
}