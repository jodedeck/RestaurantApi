namespace RestaurantApi.Migrations
{
    using RestaurantApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantApi.Models.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantApi.Models.RestaurantContext context)
        {
            var restaurants = new List<Restaurant>
                {
                    new Restaurant {Name= "Quick", Address = "Avenue Louise, 15", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "McDonald's", Address = "Cora Anderlecht", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "Pizza Hut", Address = "Cora Anderlecht", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 93", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French", Schedule = "10:18"},
                    new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 115/117", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian", Schedule = "10:18"},
                    new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 5", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian", Schedule = "10:18"},

                    new Restaurant {Name= "Quick", Address = "Avenue Louise, 151", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "McDonald's", Address = "Cora Evere", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "Pizza Hut", Address = "Cora Uccle", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 85", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French", Schedule = "10:18"},
                    new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 15", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian", Schedule = "10:18"},
                    new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 25", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian", Schedule = "10:18"},

                    new Restaurant {Name= "Quick", Address = "Avenue Louise, 125", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "McDonald's", Address = "Cora Ixelles", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "Pizza Hut", Address = "Cora Ixelles", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
                    new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 923", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French", Schedule = "10:18"},
                    new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 25", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian", Schedule = "10:18"},
                    new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 55", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian", Schedule = "10:18"}

                };

            restaurants.ForEach(r => context.Restaurants.Add(r));
            context.SaveChanges();

            //var comment = new Comment { RestaurantID = 1, content = "Un peu gras mais très rapide", rating = 7 };
            //context.Comments.Add(comment);
            //context.SaveChanges();

        
        }
    }
}
