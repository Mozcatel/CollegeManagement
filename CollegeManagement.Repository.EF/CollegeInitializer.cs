using CollegeManagement.Model;
using System;
using System.Collections.Generic;

namespace CollegeManagement.Repository.EF
{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollegeContext>
    {
        protected override void Seed(CollegeContext context)
        {
            /**** Students DB Set ****/
            var students = new List<Student>
            {
                new Student {StudentName="Bruno", StudentRegNumber=1, StudentBirthDate= new DateTime(1993,5,8)},
                new Student {StudentName="Pedro", StudentRegNumber=2, StudentBirthDate= new DateTime(2000,2,25)},
                new Student {StudentName="José", StudentRegNumber=3, StudentBirthDate= new DateTime(1990,4,6)},
                new Student {StudentName="Nuno", StudentRegNumber=4, StudentBirthDate= new DateTime(1994,8,9)},
                new Student {StudentName="Ana", StudentRegNumber=5, StudentBirthDate= new DateTime(1994,8,9)},
                new Student {StudentName="Leila", StudentRegNumber=6, StudentBirthDate= new DateTime(1994,12,19)},
                new Student {StudentName="Susana", StudentRegNumber=7, StudentBirthDate= new DateTime(1992,4,14)},
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            /**** Courses DB Set ****/
            var courses = new List<Course>
            {
                new Course {CourseName= "Engenharia Informática e de Computadores"},
                new Course {CourseName= "Engenharia Informática e de Multimédia"},
                new Course {CourseName= "Engenharia Informática e de Telecomunicações"},
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            /**** Teachers DB Set ****/
            var teachers = new List<Teacher>
            {
                new Teacher{TeacherName= "Hugo", TeacherSalary= 2000, TeacherBirthDate= new DateTime(1980,5,9)},
                new Teacher{TeacherName= "Aníbal", TeacherSalary= 1500, TeacherBirthDate= new DateTime(1980,4,9)},
                new Teacher{TeacherName= "Úrsula", TeacherSalary= 2000, TeacherBirthDate= new DateTime(1980,5,9)},
                new Teacher{TeacherName= "Rita", TeacherSalary= 1500, TeacherBirthDate= new DateTime(1980,4,9)},
                new Teacher{TeacherName= "Danilo", TeacherSalary= 2000, TeacherBirthDate= new DateTime(1980,5,9)},
                new Teacher{TeacherName= "Pascoal", TeacherSalary= 1500, TeacherBirthDate= new DateTime(1980,4,9)}
            };

            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            /**** Subjects DB Set ****/
            var subjects = new List<Subject>
            {
                new Subject{SubjectName= "Matemática 1", CourseId = 1, TeacherId= 1},
                new Subject{SubjectName= "Matemática 2", CourseId = 1, TeacherId= 2},
                new Subject{SubjectName= "Programação", CourseId = 1, TeacherId= 3},
                new Subject{SubjectName= "Sensores e Sinais", CourseId = 3, TeacherId= 4},
                new Subject{SubjectName= "Desenvolvimento Web", CourseId = 2, TeacherId= 5},
                new Subject{SubjectName= "Gestão de Projecto", CourseId = 2, TeacherId= 6},
            };

            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            /**** Grades DB Set ****/
            var grades = new List<Grade>
            {
                new Grade {GradeValue = 17, SubjectId = 1, StudentId = 1},
                new Grade {GradeValue = 16, SubjectId = 1, StudentId = 2},
                new Grade {GradeValue = 15, SubjectId = 1, StudentId = 3},
                new Grade {GradeValue = 14, SubjectId = 2, StudentId = 4},
                new Grade {GradeValue = 18, SubjectId = 2, StudentId = 5},
                new Grade {GradeValue = 16, SubjectId = 2, StudentId = 6},
                new Grade {GradeValue = 14, SubjectId = 3, StudentId = 1},
                new Grade {GradeValue = 18, SubjectId = 3, StudentId = 2},
                new Grade {GradeValue = 16, SubjectId = 3, StudentId = 3},
                new Grade {GradeValue = 14, SubjectId = 4, StudentId = 4},
                new Grade {GradeValue = 12, SubjectId = 4, StudentId = 5},
                new Grade {GradeValue = 13, SubjectId = 4, StudentId = 6},
                new Grade {GradeValue = 14, SubjectId = 5, StudentId = 1},
                new Grade {GradeValue = 18, SubjectId = 5, StudentId = 2},
                new Grade {GradeValue = 16, SubjectId = 5, StudentId = 3},
                new Grade {GradeValue = 14, SubjectId = 6, StudentId = 4},
                new Grade {GradeValue = 13, SubjectId = 6, StudentId = 5},
                new Grade {GradeValue = 16, SubjectId = 6, StudentId = 6},
            };

            grades.ForEach(g => context.Grades.Add(g));
            context.SaveChanges();
        }
    }
}