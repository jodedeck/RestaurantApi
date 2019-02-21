using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string PhoneNumber { get; set; }
        public string CookingType { get; set; }  
        public string Schedule { get; set; }
        public int AverageRating { get; set; }
        public string ImageUrl { get; set; }


    }
}