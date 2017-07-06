using System.Data.Entity.ModelConfiguration;

namespace CarSite.Models.EntityConfigurations
{
    class BranchConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchConfiguration()
        {
            HasKey(u => u.Id);

            HasRequired(b => b.City)
                .WithMany(c => c.Branches)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(true);
        }
    }
}
