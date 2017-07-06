using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarSite.Models.EntityConfigurations
{
    class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasMany(c=> c.Rents)
                .WithRequired(r=> r.Car)
                .HasForeignKey(r=> r.CarId)
                .WillCascadeOnDelete(true);

            HasRequired(c => c.CarModel)
                .WithMany(m => m.Cars)
                .HasForeignKey(m => m.CarModelId)
                .WillCascadeOnDelete(true);


            HasRequired(c => c.Branch)
                .WithMany(b => b.Cars)
                .HasForeignKey(b => b.BranchId)
                .WillCascadeOnDelete(true);


        }
    }
}
