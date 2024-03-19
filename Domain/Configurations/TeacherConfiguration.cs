using Microsoft.EntityFrameworkCore;
using University.Domain.Entity;

namespace University.Domain.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId);
            builder
                .HasMany(t => t.Lecture)
                .WithMany(lec => lec.Teacher);
                
           

        }
    }
}
