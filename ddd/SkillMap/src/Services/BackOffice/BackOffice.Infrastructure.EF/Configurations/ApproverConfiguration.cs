namespace BackOffice.Infrastructure.EF.Configurations;

public class ApproverConfiguration : IEntityTypeConfiguration<Approver>
{
    public void Configure(EntityTypeBuilder<Approver> builder)
    {
        builder.ToTable("Approvers");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Status).HasColumnName(nameof(Approver.Status).ToDatabaseFormat());
    }
}
