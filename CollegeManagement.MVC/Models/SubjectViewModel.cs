using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public int NumberOfStudents { get; set; }
    }
}