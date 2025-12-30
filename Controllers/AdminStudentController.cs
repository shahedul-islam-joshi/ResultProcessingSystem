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
            // Check if the form satisfies the [Required] attributes
            if (!ModelState.IsValid)
            {
                return View(addStudentRequest);
            }

            var student = new Student
            {
                Registration = addStudentRequest.Registration,
                Department = addStudentRequest.Department,
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                session = addStudentRequest.session,
                Address = addStudentRequest.Address,
                Gender = addStudentRequest.Gender,
                Date = addStudentRequest.Date
            };

            if (addStudentRequest.ProfileImage != null)
            {
                using var dataStream = new MemoryStream();
                await addStudentRequest.ProfileImage.CopyToAsync(dataStream);
                student.ProfilePicture = dataStream.ToArray();
            }

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
                    Registration = student.Registration,
                    Department = student.Department,
                    Name = student.Name,
                    Email = student.Email,
                    session = student.session,
                    Address = student.Address,
                    Gender = student.Gender,
                    Date = student.Date,
                    ProfilePicture = student.ProfilePicture
                };
                return View(editStudentRequest);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditStudentRequest editStudentRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(editStudentRequest);
            }

            var student = new Student
            {
                Id = editStudentRequest.Id,
                Registration = editStudentRequest.Registration,
                Department = editStudentRequest.Department,
                Name = editStudentRequest.Name,
                Email = editStudentRequest.Email,
                session = editStudentRequest.session,
                Address = editStudentRequest.Address,
                Gender = editStudentRequest.Gender,
                Date = editStudentRequest.Date
            };

            student.ProfilePicture = editStudentRequest.ProfilePicture;

            if (editStudentRequest.ProfileImage != null)
            {
                using var dataStream = new MemoryStream();
                await editStudentRequest.ProfileImage.CopyToAsync(dataStream);
                student.ProfilePicture = dataStream.ToArray();
            }

            var updatedStudent = await studentRepo.UpdateAsync(student);

            if (updatedStudent != null)
            {
                return RedirectToAction("List");
            }

            return View(editStudentRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedStudent = await studentRepo.DeleteAsync(id);
            return RedirectToAction("List");
        }
    }
}