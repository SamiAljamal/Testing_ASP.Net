using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("PlacesToVisit")]
    public class PlaceToVisit
    {
        [Key]
        public int ItemId { get; set; }
        public string City { get; set; }
        public string Description { get; set; }

        public DateTime DateToVisitBy { get; set; }
    }
}