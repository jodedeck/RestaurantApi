using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base()
        {
            this.Database.CommandTimeout = 180;
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}