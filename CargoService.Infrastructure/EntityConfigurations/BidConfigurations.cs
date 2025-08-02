using CargoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Infrastructure.EntityConfigurations
{
    public class BidConfigurations : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.Property(b => b.Price)
       .HasPrecision(18, 2) 
       .IsRequired();

            builder.HasOne(b => b.Fleet)
                      .WithMany(f => f.Bids) 
                      .HasForeignKey(b => b.FleetId)
                      .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
