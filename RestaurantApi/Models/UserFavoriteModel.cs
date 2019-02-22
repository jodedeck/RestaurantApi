using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class UserFavoriteModel
    {
        List<int> favorites;
        private RestaurantContext db = new RestaurantContext();

        public UserFavoriteModel(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Password = user.Password;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.UserRole = user.UserRole;
            UserFavorites = new List<int>();
            var favorites = db.Favorites.Where(f => f.UserId == user.Id).ToList();
            foreach (var fav in favorites)
            {
                UserFavorites.Add(fav.RestaurantId);
            }
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public Role UserRole { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<int> UserFavorites { get; set; }

       

    }
}