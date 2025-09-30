namespace ResultProcessingSystem.Models.ViewModel
{
    public class AddStudentRequest
    {
        public int Id { get; set; }  // Primary key for DB
        public int Registration { get; set; }  // Student registration number
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Session { get; set; }
    }
}
