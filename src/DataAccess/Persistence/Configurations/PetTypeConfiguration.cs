using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Persistence.Configurations;

public class PetTypeConfiguration : IEntityTypeConfiguration<PetType>
{
    public void Configure(EntityTypeBuilder<PetType> builder)
    {
        builder.ToTable("types");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80);
    }
}