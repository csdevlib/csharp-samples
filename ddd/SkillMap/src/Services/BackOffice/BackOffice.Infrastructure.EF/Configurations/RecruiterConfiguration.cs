namespace BackOffice.Infrastructure.EF.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.ToTable("Recruiters");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status).HasColumnName(nameof(Recruiter.Status).ToDatabaseFormat());
        }
    }
}
