using Furever.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furever.Entities.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasData
            (
                 new Favorite
                 {
                     UserId = 2,
                     AnimalId = 1,
                 },
                 new Favorite
                 {
                     UserId = 2,
                     AnimalId = 2,
                 },
                 new Favorite
                 {
                     UserId = 1,
                     AnimalId = 2,
                 }
            ); ;
        }
    }
}
