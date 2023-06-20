using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBookService.Web.Entities;

namespace SimpleBookService.Web.Infra.Mapping
{
    public class BookMap
    {
        protected void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.Author)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.Registration);

            entity.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
