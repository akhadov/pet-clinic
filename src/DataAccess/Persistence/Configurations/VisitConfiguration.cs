using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Persistence.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.VisitDate)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();


    }
}