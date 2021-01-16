using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}