using Company = BackOffice.Models.Company;

namespace BackOffice.Infrastructure.EF.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", BackOfficeContext.DEFAULT_SCHEMA);
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnName(nameof(Company.Name).ToDatabaseFormat());

        builder.Property(x => x.Status).HasColumnName(nameof(Company.Status).ToDatabaseFormat());

        var navigationApprovers = builder.Metadata.FindNavigation(nameof(Company.Approvers));
        navigationApprovers?.SetPropertyAccessMode(PropertyAccessMode.Field);

        var navigationRecruiters = builder.Metadata.FindNavigation(nameof(Company.Recruiters));
        navigationRecruiters?.SetPropertyAccessMode(PropertyAccessMode.Field);

        var navigationTalents = builder.Metadata.FindNavigation(nameof(Company.Talents));
        navigationTalents?.SetPropertyAccessMode(PropertyAccessMode.Field);

        var navigationEmployees = builder.Metadata.FindNavigation(nameof(Company.Employees));
        navigationEmployees?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}

