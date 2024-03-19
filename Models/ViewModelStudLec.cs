using University.Domain.Entity;

namespace University.Models
{
    public class ViewModelStudLec
    {
        public IEnumerable <Stud> Studs { get; set; }
        public IEnumerable <Lecture> Lectures { get; set; }

        public IEnumerable<Labwork> Labworks { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Review> Review {  get; set; }    
       
    }
}
