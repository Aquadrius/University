using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entity
{
    public class Labwork
    {
        
        public int LabworkId { get; set; }        
        
        public string LabworkName { get; set; }=string.Empty;

        public int LectureId { get; set; }

        public Lecture? Lecture { get; set; }

        public Review? Review { get; set; }

        public Grade? Grade { get; set; }

        public List<Stud> Stud { get; set; } = [];




    }
}
