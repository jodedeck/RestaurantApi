using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string FoodType { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
    }
}