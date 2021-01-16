using System.Collections.Generic;
using TravelTrip.Entity.Concrete;

namespace TravelTrip.Models
{
    public class CommentBlogViewModel
    {
        public IEnumerable<Comments> Comments { get; set; }
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<Blog> LastBlogs { get; set; }
        public IEnumerable<Comments> LastComments { get; set; }
    }
}