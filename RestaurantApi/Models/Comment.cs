using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class Comment
    {
        public int Id { get; set; }       
        public int RestaurantID { get; set; }
        public string Content { get; set; }      
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public string UserName { get; set; }
    }
}