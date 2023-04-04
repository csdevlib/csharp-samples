using Catalog.Domain.Aggregates.AlbumAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.EntityConfigurations
{
    public class SongEntityTypeConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("orderItems", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id).HasName("SongId");

            builder.Property<string>("AlbumId")
              .IsRequired();

            builder.Ignore(b => b.DomainEvents);

            builder.Property<string>("Name").IsRequired(true);

            builder.Property<string>("Description").IsRequired(false);

            builder.Property<string>("Tags").IsRequired(false);

            builder.Property<double>("Duration").IsRequired(true);

            builder.Property<bool>("IsDraft").IsRequired(true);

            //Value objects persisted as owned entity type supported since EF Core 2.0
            builder
                .OwnsOne(o => o.Author, a =>
                {
                    // Explicit configuration of the shadow key property in the owned type 
                    // as a workaround for a documented issue in EF Core 5: https://github.com/dotnet/efcore/issues/20740
                    a.Property<string>("SongId");
                    a.WithOwner();
                });

            builder
                .OwnsOne(o => o.Audit, a =>
                {
                    // Explicit configuration of the shadow key property in the owned type 
                    // as a workaround for a documented issue in EF Core 5: https://github.com/dotnet/efcore/issues/20740
                    a.Property<string>("SongId");
                    a.WithOwner();
                });

            builder
              .Property<int>("Status")
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("Status")
              .IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Song.Files));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the Song collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
