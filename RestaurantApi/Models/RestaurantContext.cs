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
    }
}