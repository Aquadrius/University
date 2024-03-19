using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entity;

namespace University.Domain.Configurations
{
    public class LabworkConfiguration : IEntityTypeConfiguration<Labwork>
    {
        public void Configure(EntityTypeBuilder<Labwork> builder)
        {
            builder.HasKey(lab => lab.LabworkId);          
                                     

            builder
                     
                    .HasMany(lab => lab.Stud)
                    .WithMany (s => s.Labwork);

            builder
                    .HasOne(lab => lab.Lecture)
                    .WithMany(lec => lec.Labwork)
                    .HasForeignKey(lab=>lab.LectureId);

                            


        }
    }
}
