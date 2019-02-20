using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Starter { get; set; }
        public string Dish { get; set; }
        public string Dessert { get; set; }
        public int RestaurantId { get; set; }
    }
}