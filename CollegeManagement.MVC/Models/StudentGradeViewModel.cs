using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class StudentGradeViewModel
    {
        public int StudentId { get; set; }
        public int StudentRegNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentBirthDate { get; set; }
        public int GradeValue { get; set; }
    }
}