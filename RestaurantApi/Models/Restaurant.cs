using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int PhoneNumber { get; set; }
        public string CookingType { get; set; }


    }
}