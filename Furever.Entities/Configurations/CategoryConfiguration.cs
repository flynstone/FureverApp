using Furever.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furever.Entities.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Category
                {
                    Id = 1,
                    Species = "Dogs",
                },
                new Category
                {
                    Id = 2,
                    Species = "Cats",
                },
                 new Category
                 {
                     Id = 3,
                     Species = "Birds",
                 },
                 new Category
                 {
                     Id = 4,
                     Species = "Reptiles",
                 }
            ); ;
        }
    }
}
