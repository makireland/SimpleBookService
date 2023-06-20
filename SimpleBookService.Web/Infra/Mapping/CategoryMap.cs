using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBookService.Web.Entities;

namespace SimpleBookService.Web.Infra.Mapping
{
    public class CategoryMap
    {
        protected void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
