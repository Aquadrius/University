using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entity;

namespace University.Domain.Configurations
{
    public class StudConfiguration : IEntityTypeConfiguration<Stud>
    {
        public void Configure(EntityTypeBuilder<Stud> builder)
        {
            builder.HasKey(s => s.StudId);

            builder
                .HasMany(s => s.Labwork)
                .WithMany(lab => lab.Stud);
                
            builder
                .HasMany(s => s.Lecture)
                .WithMany(lec => lec.Stud);

          

        }
    }
}
