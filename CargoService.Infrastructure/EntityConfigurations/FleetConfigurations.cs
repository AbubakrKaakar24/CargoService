using CargoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CargoService.Infrastructure.EntityConfigurations
{
    public class FleetConfigurations : IEntityTypeConfiguration<Fleet>
    {
        public void Configure(EntityTypeBuilder<Fleet> builder)
        {
            builder.HasMany(f => f.Bids)
                   .WithOne(b => b.Fleet)
                   .HasForeignKey(b => b.FleetId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
