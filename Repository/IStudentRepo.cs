using ResultProcessingSystem.Models.Domain;

namespace ResultProcessingSystem.Repository
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetAsync(int id);
        Task<Student?>AddAsync(Student student);
        Task<Student?>UpdateAsync(Student student);
        Task<Student?>DeleteAsync(int id);

    }
}
