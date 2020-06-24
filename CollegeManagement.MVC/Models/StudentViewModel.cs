using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public int StudentRegNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentBirthDate { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}