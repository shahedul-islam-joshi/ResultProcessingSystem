using Microsoft.AspNetCore.Mvc;
using ResultProcessingSystem.Data;
using ResultProcessingSystem.Models.Domain;
using ResultProcessingSystem.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using ResultProcessingSystem.Repository;


namespace ResultProcessingSystem.Controllers
{
    public class AdminStudentController : Controller
    {
        private readonly IStudentRepo studentRepo;

        public AdminStudentController(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Add(AddStudentRequest addStudentRequest)
        {
            var student = new Student
            {
                Name = addStudentRequest.Name,
                Department = addStudentRequest.Department,
                Registration = addStudentRequest.Registration,
                Session = addStudentRequest.Session
            };
            await studentRepo.AddAsync(student);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await studentRepo.GetAllAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await studentRepo.GetAsync(id);
            if (student != null)
            {
                var editStudentRequest = new EditStudentRequest
                {
                    Id = student.Id,
                    Name = student.Name,
                    Department = student.Department,
                    Registration = student.Registration,
                    Session = student.Session
                };
                return View(editStudentRequest);
            }
            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStudentRequest editStudentRequest)
        {
            var student = new Student
            {
                Id=editStudentRequest.Id,
                Name = editStudentRequest.Name,
                Department = editStudentRequest.Department,
                Registration = editStudentRequest.Registration,
                Session = editStudentRequest.Session
            };
            var updatedStudent = await studentRepo.UpdateAsync(student);
            if (updatedStudent != null)
            { 
                return RedirectToAction("List");
            }
            return View(editStudentRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditStudentRequest editStudentRequest)
        {
           var deletedStudent = await studentRepo.DeleteAsync(editStudentRequest.Id);
            if (deletedStudent != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}
