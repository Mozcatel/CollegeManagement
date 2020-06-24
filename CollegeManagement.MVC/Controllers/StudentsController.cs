using CollegeManagement.Model;
using CollegeManagement.MVC.Models;
using CollegeManagement.MVC.Utils;
using CollegeManagement.Repository.EF;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeManagement.MVC.Controllers
{
    public class StudentsController : UnitOfWorkController
    {
        // GET: Students
        public async Task<ActionResult> Index()
        {
            var students = await _unitOfWork.Students.GetAsync();

            return View(students.MapToStudentViewModel());
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _unitOfWork.Students.GetAsync(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student.MapToStudentDetailView());
        }

        // GET: Students/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.SubjectId = new SelectList(await _unitOfWork.Subjects.GetAsync(), "SubjectId", "SubjectName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,StudentName,StudentRegNumber,StudentBirthDate")] Student student,
                                               [Bind(Include = "SubjectName")] string subjectName,
                                               [Bind(Include = "GradeValue")] int gradeValue)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Insert(student);
                var subject = await _unitOfWork.Subjects.GetByNameAsync(subjectName);
                if (subject == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                _unitOfWork.Grades.Insert(
                    new Grade
                    {
                        StudentId = student.StudentId,
                        SubjectId = subject.SubjectId,
                        GradeValue = gradeValue
                    });
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _unitOfWork.Students.GetAsync(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,StudentName,StudentBirthDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Update(student);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _unitOfWork.Students.GetAsync(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await _unitOfWork.Students.GetAsync(id);
            _unitOfWork.Students.Delete(student);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}