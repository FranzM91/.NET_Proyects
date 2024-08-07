using manilab.Entities;
using System.Data.Entity;

namespace manilab.test
{
    public class ManilabContext: DbContext
    {
        public DbSet<Users> users { get; set; }

        public ManilabContext() : base("ManilabContext")
        {

            // IMPORTANT: comment this line if you migrate the database or add new columns in models
            //Database.SetInitializer<ManilabContext>(null);
            Database.SetInitializer<ManilabContext>(new DropCreateDatabaseIfModelChanges<ManilabContext>());
        }
        public static ManilabContext Create()
        {
            return new ManilabContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
