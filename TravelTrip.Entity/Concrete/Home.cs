using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class Home
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}