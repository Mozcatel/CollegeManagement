using System.Collections;
using System.Collections.Generic;

namespace CollegeManagement.Model
{
    public class Subject
    {
        public Subject()
        {
            this.Grades = new HashSet<Grade>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}