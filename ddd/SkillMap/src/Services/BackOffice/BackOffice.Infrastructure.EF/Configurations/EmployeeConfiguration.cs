namespace BackOffice.Infrastructure.EF.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Name).HasColumnName(nameof(Employee.Name).ToDatabaseFormat());

            builder.Property(x => x.Status).HasColumnName(nameof(Employee.Status).ToDatabaseFormat());
        }
    }
}
