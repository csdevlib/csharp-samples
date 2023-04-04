namespace BackOffice.Infrastructure.EF.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Models.Tag>
    {
        public void Configure(EntityTypeBuilder<Models.Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName(nameof(Models.Tag.Name).ToDatabaseFormat());
            builder.Property(x => x.Description).HasColumnName(nameof(Models.Tag.Description).ToDatabaseFormat());
            builder.Property(x => x.Status).HasColumnName(nameof(Models.Tag.Status).ToDatabaseFormat());
        }
    }
}
