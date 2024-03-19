using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entity
{
    public class Stud: Person
    {
        public int StudId { get; set; }

        public int Kurs { get; set; }

        public List<Labwork> Labwork { get; set; } = [];

        public List<Lecture> Lecture { get; set; } = [];

        public Review? Review { get; set; }

        public Grade? Grade { get; set; }


    }
}
