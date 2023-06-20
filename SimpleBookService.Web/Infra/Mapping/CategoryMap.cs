using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBookService.Web.Models.Entities;

namespace SimpleBookService.Web.Infra.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasMany(Category => Category.Books)
                .WithMany();
        }
    }
}
