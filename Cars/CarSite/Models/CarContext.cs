using CarSite.Models.EntityConfigurations;
using System.Data.Entity;

namespace CarSite.Models
{
    public class CarContext:DbContext
    {
        public CarContext()
            :base("name=CarDB")
        {
 
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(true));

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CarConfiguration());
            modelBuilder.Configurations.Add(new CarModelConfiguration());
            modelBuilder.Configurations.Add(new BranchConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
