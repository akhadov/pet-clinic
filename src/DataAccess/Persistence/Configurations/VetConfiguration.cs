using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Persistence.Configurations;

public class VetConfiguration : IEntityTypeConfiguration<Vet>
{
    public void Configure(EntityTypeBuilder<Vet> builder)
    {
        builder.HasKey(x => x.Id);

        //builder.Property(x => x.FirstName)
        //    .IsRequired()
        //    .HasMaxLength(30);

        //builder.Property(x => x.LastName)
        //    .IsRequired()
        //    .HasMaxLength(30);

        builder.HasMany(x => x.Specialties)
            .WithMany("Vets")
            .UsingEntity(x => x.ToTable("VetSpecialties"));
    }
}
