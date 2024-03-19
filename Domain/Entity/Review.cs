namespace University.Domain.Entity
{
    public class Review
    {
        public int RewiewId { get; set; }

        public string RewiewName { get; set; }

        public int LabworkId { get; set; }

        public int StudId { get; set; }

        public List<Stud> Stud { get; set; } = [];

        public List<Labwork> Labwork { get; set; } = [];
    }
}
