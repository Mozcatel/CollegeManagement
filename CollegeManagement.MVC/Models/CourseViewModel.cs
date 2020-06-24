using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class CourseViewModel
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int? NumberOfStudents { get; set; }
        public int? NumberOfTeachers { get; set; }
        public int? GradeAverage { get; set; }
    }
}