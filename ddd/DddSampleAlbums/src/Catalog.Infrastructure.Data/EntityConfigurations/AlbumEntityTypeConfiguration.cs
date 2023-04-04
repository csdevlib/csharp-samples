using Catalog.Domain.Aggregates.AlbumAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.EntityConfigurations
{
    public class AlbumEntityTypeConfiguration: IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("albums", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id).HasName("AlbumId");

            builder.Ignore(b => b.DomainEvents);

            builder
               .Property<int?>("_albumTypeId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("AlbumTypeId")
               .IsRequired(false);


            //Value objects persisted as owned entity type supported since EF Core 2.0
            builder
                .OwnsOne(o => o.Author, a =>
                {
                    // Explicit configuration of the shadow key property in the owned type 
                    // as a workaround for a documented issue in EF Core 5: https://github.com/dotnet/efcore/issues/20740
                    a.Property<string>("AlbumId");
                    a.WithOwner();
                });

            builder
                .OwnsOne(o => o.Audit, a =>
                {
                    // Explicit configuration of the shadow key property in the owned type 
                    // as a workaround for a documented issue in EF Core 5: https://github.com/dotnet/efcore/issues/20740
                    a.Property<string>("AlbumId");
                    a.WithOwner();
                });

            builder
              .Property<int>("Status")
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("Status")
              .IsRequired();

            builder.Property<string>("Name").IsRequired(true);

            builder.Property<string>("Description").IsRequired(false);

            builder.Property<string>("Tags").IsRequired(false);

            var navigation = builder.Metadata.FindNavigation(nameof(Album.Songs));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the Song collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<AlbumType>()
                .WithMany()
                .HasForeignKey("_albumTypeId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
