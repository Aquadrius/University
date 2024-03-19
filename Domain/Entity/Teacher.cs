using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Domain.Entity
{
    public class Teacher:Person
    {
        
        public int TeacherId { get; set; }
        public List<Lecture> Lecture { get; set; } = [];
    }
}
