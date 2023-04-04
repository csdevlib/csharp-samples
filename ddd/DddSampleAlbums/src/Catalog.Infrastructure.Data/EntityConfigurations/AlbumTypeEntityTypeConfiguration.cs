using Catalog.Domain.Aggregates.AlbumAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.EntityConfigurations
{
    public class AlbumTypeEntityTypeConfiguration : IEntityTypeConfiguration<AlbumType>
    {
        public void Configure(EntityTypeBuilder<AlbumType> builder)
        {
            builder.ToTable("albumtypes", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(b => b.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(b => b.Id)
                .UseHiLo("albumtypeseq", CatalogContext.DEFAULT_SCHEMA);

            builder.Property<string>("Name").IsRequired(true);
        }
    }
}
