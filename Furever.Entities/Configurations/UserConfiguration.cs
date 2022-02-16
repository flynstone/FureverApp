using Furever.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furever.Entities.Configurations
{ 
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "User"
                },
                new User
                {
                    Id = 2,
                    FirstName = "User",
                    LastName = "Test"
                }
            ); ;
        }
    }
}
