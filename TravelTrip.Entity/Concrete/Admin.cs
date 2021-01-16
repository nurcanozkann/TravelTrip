using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}