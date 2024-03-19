namespace University.Domain.Entity
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int Meaning{ get; set; }

        public int LabworkId { get; set; }

        public int StudId { get; set; }

        public List<Stud> Stud { get; set; } = [];

        public List<Labwork> Labwork { get; set; } = [];
    }
}
