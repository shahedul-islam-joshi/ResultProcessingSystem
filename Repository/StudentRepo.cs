using Microsoft.EntityFrameworkCore;
using ResultProcessingSystem.Data;
using ResultProcessingSystem.Models.Domain;

namespace ResultProcessingSystem.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepo(StudentDbContext studentDbContext)
        {
            this._studentDbContext = studentDbContext;
        }
        public async Task<Student?> AddAsync(Student student)
        {
            await _studentDbContext.Students.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var existingStudent = await _studentDbContext.Students.FindAsync(id);
            if (existingStudent != null)
            {
                _studentDbContext.Students.Remove(existingStudent);
                await _studentDbContext.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetAsync(int id)
        {
            return await _studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            var existingStudent = await _studentDbContext.Students.FindAsync(student.Id);
            if (existingStudent != null)
            {
                existingStudent.Id = student.Id;
                existingStudent.Name = student.Name;
                existingStudent.Session = student.Session;
                existingStudent.Registration = student.Registration;
                existingStudent.Department = student.Department;
                await _studentDbContext.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }
    }
}
