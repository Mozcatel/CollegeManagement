using System;
using System.Collections;
using System.Collections.Generic;

namespace CollegeManagement.Model
{
    public class Student
    {
        public Student()
        {
            this.Grades = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public int StudentRegNumber { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}