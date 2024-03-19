using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entity
{
    public class Lecture
    {
       
        public int LectureId { get; set; }
       
        public string LectureName { get; set; }= string.Empty;

        public string Info { get; set; }=string.Empty;
        
        public List<Labwork> Labwork { get; set; } = [];

        public List<Teacher> Teacher { get; set; } = [];

        public List<Stud> Stud { get; set; } = [];
    }
}
