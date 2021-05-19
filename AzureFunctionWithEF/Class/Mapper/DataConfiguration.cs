using AzureFunctionWithEF.Class.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionWithEF.Class.Mapper
{
    public class DataConfiguration : IEntityTypeConfiguration<Data>
    {
        public void Configure(EntityTypeBuilder<Data> builder)
        {
            builder.HasKey(x => x.Username);
            builder.Property(x => x.Username)
                .HasColumnName("Username")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .IsRequired();

            builder.Property(x => x.AccesskeyID)
                .HasColumnName("AccesskeyID")
                .IsRequired();

            builder.Property(x => x.Consoleloginlink)
                .HasColumnName("Consoleloginlink");

            builder.Property(x => x.Secretaccesskey)
                .HasColumnName("Secretaccesskey")
                .IsRequired();
        }
    }
}
