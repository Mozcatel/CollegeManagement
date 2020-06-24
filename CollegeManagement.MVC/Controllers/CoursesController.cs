using CollegeManagement.Model;
using CollegeManagement.MVC.Models;
using CollegeManagement.MVC.Utils;
using CollegeManagement.Repository.EF;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeManagement.MVC.Controllers
{
    public class CoursesController : UnitOfWorkController
    {
        // GET: Courses
        public async Task<ActionResult> Index()
        {
            var courses = await _unitOfWork.Courses.GetAsync();

            return View(courses.MapToCourseViewModel());
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = await _unitOfWork.Courses.GetAsync(id.Value);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course.MapToCourseDetailView());
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,CourseName")] Course Course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Insert(Course);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(Course);
        }

        // GET: Courses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course Course = await _unitOfWork.Courses.GetAsync(id.Value);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseId,CourseName")] Course Course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Update(Course);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Course);
        }

        // GET: Courses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course Course = await _unitOfWork.Courses.GetAsync(id.Value);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Course Course = await _unitOfWork.Courses.GetAsync(id);
            _unitOfWork.Courses.Delete(Course);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}