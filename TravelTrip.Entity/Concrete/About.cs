using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class About
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}