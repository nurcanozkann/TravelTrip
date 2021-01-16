using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class AddressBlog
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string AddressOpen { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
    }
}