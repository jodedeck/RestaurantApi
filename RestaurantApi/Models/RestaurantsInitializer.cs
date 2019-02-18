using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class RestaurantsInitializer : DropCreateDatabaseAlways<RestaurantContext>
    {

        protected override void Seed(RestaurantContext context)
        {

            var restaurants = new List<Restaurant>
            {
                new Restaurant {Name= "Quick", Address = "Avenue Louise, 15", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American"},
                new Restaurant {Name= "McDonald's", Address = "Cora Anderlecht", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American"},
                new Restaurant {Name= "Pizza Hut", Address = "Cora Anderlecht", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American"},
                new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 93", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French"},
                new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 115/117", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian"},
                new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 5", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian"}

            };

            restaurants.ForEach(r => context.Restaurants.Add(r));
            context.SaveChanges();

            
        }
    }
}