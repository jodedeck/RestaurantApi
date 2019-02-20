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
            //var restaurants = new List<Restaurant>
            //    {
            //        new Restaurant {Name= "Quick", Address = "Avenue Louise, 15", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "McDonald's", Address = "Cora Anderlecht", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "Pizza Hut", Address = "Cora Anderlecht", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 93", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French", Schedule = "10:18"},
            //        new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 115/117", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian", Schedule = "10:18"},
            //        new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 5", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian", Schedule = "10:18"},

            //        new Restaurant {Name= "Quick", Address = "Avenue Louise, 151", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "McDonald's", Address = "Cora Evere", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "Pizza Hut", Address = "Cora Uccle", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 85", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French", Schedule = "10:18"},
            //        new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 15", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian", Schedule = "10:18"},
            //        new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 25", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian", Schedule = "10:18"},

            //        new Restaurant {Name= "Quick", Address = "Avenue Louise, 125", Description = "fastfood", PhoneNumber = 025202020, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "McDonald's", Address = "Cora Ixelles", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "Pizza Hut", Address = "Cora Ixelles", Description = "fastfood", PhoneNumber = 025245122, CookingType = "American", Schedule = "10:18"},
            //        new Restaurant {Name= "Exki", Address = "rue marché aux herbes, 923", Description = "cuisine fraîche", PhoneNumber = 025246152, CookingType = "French", Schedule = "10:18"},
            //        new Restaurant {Name= "Dolce Amaro", Address = "Chaussee de Charleroi 25", Description = "pizzeria", PhoneNumber = 025246152, CookingType = "Italian", Schedule = "10:18"},
            //        new Restaurant {Name= "Makisu", Address = "Rue du Bailli, 55", Description = "sushi et maki", PhoneNumber = 025246152, CookingType = "Asian", Schedule = "10:18"}

            //    };

            //restaurants.ForEach(r => context.Restaurants.Add(r));
            //context.SaveChanges();

            //var comment = new Comment { RestaurantID = 1, content = "Un peu gras mais très rapide", rating = 7 };
            //context.Comments.Add(comment);
            //context.SaveChanges();

            var foods = new List<Food>
            {
                new Food {FoodType = "Starter", Description= "un croissant et une couque au chocolat", Name = "petit dej", Price = 5, RestaurantId = 1 },
                new Food {FoodType = "Dish", Description= "fritte, boisson et un giant", Name = "Menu Giant", Price = 8, RestaurantId = 1 },
                new Food {FoodType = "Dessert", Description= "une boule vanille, chocolat et un coulis de chocolat", Name = "Dame-Blanche", Price = 4, RestaurantId = 1 },

                new Food {FoodType = "Starter", Description= "un croissant et deux couque au chocolat", Name = "petit dej", Price = 5, RestaurantId = 2 },
                new Food {FoodType = "Dish", Description= "fritte, boisson et un giant", Name = "Menu BigMac", Price = 8, RestaurantId = 2 },
                new Food {FoodType = "Dessert", Description= "une boule vanille, chocolat et un coulis de chocolat", Name = "Dame-Blanche", Price = 4, RestaurantId = 2 },

                new Food {FoodType = "Starter", Description= "soupe miso avec vermicelle", Name = "soupe du jour", Price = 6, RestaurantId = 6 },
                new Food {FoodType = "Dish", Description= "porc pané accompagné de riz", Name = "Katsudon", Price = 11, RestaurantId = 6 },
                new Food {FoodType = "Dessert", Description= "une boule vanille, chocolat et un coulis de chocolat", Name = "Dame-Blanche", Price = 11, RestaurantId = 6 },

                new Food {FoodType = "Starter", Description= "soupe miso avec vermicelle", Name = "soupe du jour", Price = 6, RestaurantId = 12 },
                new Food {FoodType = "Dish", Description= "porc pané accompagné de riz", Name = "Katsudon", Price = 11, RestaurantId = 12 },
                new Food {FoodType = "Dessert", Description= "une boule vanille, chocolat et un coulis de chocolat", Name = "Dame-Blanche", Price = 8, RestaurantId = 12 },

                new Food {FoodType = "Starter", Description= "Salade romaine avec des oeufs et des tomates", Name = "Salade du chef", Price = 9, RestaurantId = 5 },
                new Food {FoodType = "Dish", Description= "Pizza simple, tomate et mozarella", Name = "Marguerita", Price = 15, RestaurantId = 5 },
                new Food {FoodType = "Dessert", Description= "tiramisu avec des speculoses", Name = "Tiramisu du chef", Price = 4, RestaurantId = 5 },

                new Food {FoodType = "Starter", Description= "Salade romaine avec des oeufs et des tomates", Name = "Salade du chef", Price = 9, RestaurantId = 11},
                new Food {FoodType = "Dish", Description= "Pizza simple, tomate et mozarella", Name = "Marguerita", Price = 15, RestaurantId = 11 },
                new Food {FoodType = "Dessert", Description= "tiramisu avec des speculoses", Name = "Tiramisu du chef", Price = 4, RestaurantId = 11 },

                new Food {FoodType = "Starter", Description= "salade variée", Name = "Veggan Box", Price = 114, RestaurantId = 4},
                new Food {FoodType = "Dish", Description= "club sandwitch produits bio", Name = "Tartines bio", Price = 15, RestaurantId = 4 },
                new Food {FoodType = "Dessert", Description= "tarte aux cerises", Name = "tarte de chez françoise", Price = 4, RestaurantId = 4 },

                new Food {FoodType = "Starter", Description= "salade variée", Name = "Veggan Box", Price = 15, RestaurantId = 10},
                new Food {FoodType = "Dish", Description= "club sandwitch produits bio", Name = "Tartines bio", Price = 12, RestaurantId = 10 },
                new Food {FoodType = "Dessert", Description= "tarte aux cerises", Name = "tarte de chez françoise", Price = 14, RestaurantId = 10 },
            };

            foods.ForEach(f => context.Foods.Add(f));
            context.SaveChanges();
           


        
        }
    }
}
