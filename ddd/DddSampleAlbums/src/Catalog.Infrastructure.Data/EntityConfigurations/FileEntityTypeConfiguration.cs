using Catalog.Domain.Aggregates.AlbumAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.EntityConfigurations
{
    public class FileEntityTypeConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("files", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id).HasName("FileId");

            builder.Property<string>("SongId")
              .IsRequired();

            builder.Property<string>("Name").IsRequired(true);

            builder.Property<string>("Description").IsRequired(false);

            builder.Property<string>("Path").IsRequired(true);
        }
    }
}
