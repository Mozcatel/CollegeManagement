using System;
using System.Collections.Generic;

namespace CollegeManagement.Model
{
    public class Teacher
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime TeacherBirthDate { get; set; }
        public int TeacherSalary { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}