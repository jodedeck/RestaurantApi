using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class Favorite
    {
        public int Id {get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
    }
}