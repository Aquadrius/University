using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entity;

namespace University.Domain.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasKey(lec => lec.LectureId);

            builder
                    .HasMany(lec => lec.Labwork)
                    .WithOne(lab => lab.Lecture);
                    

            builder
                     .HasMany(lec => lec.Teacher)
                     .WithMany(t => t.Lecture);


            builder
                     .HasMany(lec => lec.Stud)
                     .WithMany(s => s.Lecture);
                     
                     
                                   
            
        }
    }
}
