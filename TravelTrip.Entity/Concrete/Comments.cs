using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Mail { get; set; }
        public string Comment { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}