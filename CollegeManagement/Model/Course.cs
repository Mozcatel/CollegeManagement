using System.Collections.Generic;

namespace CollegeManagement.Model
{
    public class Course
    {
        public Course()
        {
            this.Subjects = new HashSet<Subject>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}