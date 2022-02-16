

using Furever.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furever.Entities.Configurations
{
    public class RefugeConfiguration : IEntityTypeConfiguration<Refuge>
    {
        public void Configure(EntityTypeBuilder<Refuge> builder)
        {
            builder.HasData
            (
                new Refuge
                {
                    Id = 1,
                    Username = "Testing",
                    FirstName = "Owner",
                    LastName = "Test",
                    Address = "123 Fake Avenue",
                    City = "Ottawa",
                    Email = "owner@test.com"
                },
                new Refuge
                {
                    Id = 2,
                    Username = "Guest_01",
                    FirstName = "Test",
                    LastName = "Owner",
                    Address = "123 Fake Street",
                    City = "Montreal",
                    Email = "test@owner.com"
                }
            ); ;
        }
    }
}
