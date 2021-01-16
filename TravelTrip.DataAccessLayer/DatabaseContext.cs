using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TravelTrip.Entity.Concrete;

namespace TravelTrip.DataAccessLayer.Concrete.Entity_Framework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Name=DatabaseContext")
        {
        }

        private DbSet<Admin> Admins { get; set; }
        private DbSet<AddressBlog> AddressBlogs { get; set; }
        private DbSet<Blog> Blogs { get; set; }
        private DbSet<About> Abouts { get; set; }
        private DbSet<Contact> Contacts { get; set; }
        private DbSet<Comments> Comments { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    base.OnModelCreating(modelBuilder); 
        //}
    }
}