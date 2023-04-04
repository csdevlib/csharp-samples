using SkillMap.SharedKernel.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BackOffice.Models;
using SkillMap.SharedKernel.Extensions.EntityFramework;

namespace BackOffice.Infrastructure.EF.Configurations
{
    public class TalentConfiguration : IEntityTypeConfiguration<Talent>
    {
        public void Configure(EntityTypeBuilder<Talent> builder)
        {
            builder.ToTable("Talents");

            builder.Property(x => x.Name).HasColumnName(nameof(Talent.Name).ToDatabaseFormat());
            builder.Property(x => x.Type).HasColumnName(nameof(Talent.Type).ToDatabaseFormat());
            builder.Property(x => x.Status).HasColumnName(nameof(Talent.Status).ToDatabaseFormat());
        }
    }
}
