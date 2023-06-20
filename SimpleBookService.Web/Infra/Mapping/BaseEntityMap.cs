using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleBookService.Web.Infra.Mapping
{
    public class BaseEntityMap<TEntityType> : IEntityTypeConfiguration<TEntityType> where TEntityType : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntityType> builder)
        {
            builder.HasKey(x => x.GetType());
        }
    }
}
