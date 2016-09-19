using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("BlogPosts")]
    public class BlogPost
    {
        [Key]
        public int ItemId { get; set; }
        public string City { get; set; }
        public string Description { get; set; }

        public DateTime DateToVisitBy { get; set; }
    }
}
