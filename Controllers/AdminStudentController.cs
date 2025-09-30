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
    }
}
