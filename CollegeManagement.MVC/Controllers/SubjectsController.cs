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
    public class SubjectsController : UnitOfWorkController
    {
        // GET: Subjects
        public async Task<ActionResult> Index()
        {
            var subjects = await _unitOfWork.Subjects.GetAsync();

            return View(subjects.MapToSubjectViewModel());
        }

        // GET: Subjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await _unitOfWork.Subjects.GetAsync(id.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject.MapToSubjectDetailView());
        }

        // GET: Subjects/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CourseId = new SelectList(await _unitOfWork.Courses.GetAsync(), "CourseId", "CourseName");
            ViewBag.TeacherId = new SelectList(await _unitOfWork.Teachers.GetAsync(), "TeacherId", "TeacherName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubjectId,SubjectName,CourseId,TeacherId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subjects.Insert(subject);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(await _unitOfWork.Courses.GetAsync(), "CourseId", "CourseName", subject.CourseId);
            ViewBag.TeacherId = new SelectList(await _unitOfWork.Teachers.GetAsync(), "TeacherId", "TeacherName", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await _unitOfWork.Subjects.GetAsync(id.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(await _unitOfWork.Courses.GetAsync(), "CourseId", "CourseName", subject.CourseId);
            ViewBag.TeacherId = new SelectList(await _unitOfWork.Teachers.GetAsync(), "TeacherId", "TeacherName", subject.TeacherId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubjectId,SubjectName,CourseId,TeacherId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subjects.Update(subject);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(await _unitOfWork.Courses.GetAsync(), "CourseId", "CourseName", subject.CourseId);
            ViewBag.TeacherId = new SelectList(await _unitOfWork.Teachers.GetAsync(), "TeacherId", "TeacherName", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await _unitOfWork.Subjects.GetAsync(id.Value);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subject subject = await _unitOfWork.Subjects.GetAsync(id);
            _unitOfWork.Subjects.Delete(subject);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}