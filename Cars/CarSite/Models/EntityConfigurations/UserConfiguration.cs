using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarSite.Models.EntityConfigurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
               

            HasMany(u => u.Roles)
            .WithRequired(r => r.User)
            .HasForeignKey(r => r.UserId)
            .WillCascadeOnDelete(true);

            HasMany(u => u.Rents)
            .WithOptional(r => r.User)
            .HasForeignKey(r => r.UserId)
            .WillCascadeOnDelete(true);

       
        }
    }
}
