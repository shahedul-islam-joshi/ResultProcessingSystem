using Microsoft.AspNetCore.Mvc;
using ResultProcessingSystem.Data;
using ResultProcessingSystem.Models.Domain;
using ResultProcessingSystem.Models.ViewModel;

namespace ResultProcessingSystem.Controllers
{
    public class AdminStudentController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public AdminStudentController(StudentDbContext studentDbContext)
        {
            this._studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Add(AddStudentRequest addStudentRequest)
        {
            var student = new Student
            {
                Name = addStudentRequest.Name,
                Department = addStudentRequest.Department,
                Registration = addStudentRequest.Registration,
                Session = addStudentRequest.Session
            };
            _studentDbContext.Students.Add(student);
            _studentDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = _studentDbContext.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                var editStudentRequest = new EditStudentRequest
                {
                    Id = id,
                    Registration = student.Registration,
                    Name = student.Name,
                    Department = student.Department,
                    Session = student.Session
                };
                return View(editStudentRequest);
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult Edit(EditStudentRequest editStudentRequest)
        {
            var student = new Student
            {
                Name = editStudentRequest.Name,
                Department = editStudentRequest.Department,
                Registration = editStudentRequest.Registration,
                Session = editStudentRequest.Session
            };
            var existingStudent = _studentDbContext.Students.Find(editStudentRequest.Id);
            if (existingStudent != null)
            {
                existingStudent.Session = editStudentRequest.Session;
                existingStudent.Registration = editStudentRequest.Registration;
                existingStudent.Name = editStudentRequest.Name;
                existingStudent.Department = editStudentRequest.Department;
                _studentDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(editStudentRequest);
        }
        [HttpPost]
        public IActionResult Delete(EditStudentRequest editStudentRequest)
        {
            var student = _studentDbContext.Students.Find(editStudentRequest.Id);
            if (student != null)
            {
                _studentDbContext.Students.Remove(student);
                _studentDbContext.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
