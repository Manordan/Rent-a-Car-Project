using System.Data.Entity.ModelConfiguration;

namespace CarSite.Models.EntityConfigurations
{
    class CarModelConfiguration : EntityTypeConfiguration<CarModel>
    {
        public CarModelConfiguration()
        {
            HasKey(u => u.Id);

            HasRequired(c => c.CarManufacturer)
                .WithMany(m => m.CarModels)
                .HasForeignKey(m => m.CarManufacturerId)
                .WillCascadeOnDelete(false);
        }
    }
}
