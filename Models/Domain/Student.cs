namespace ResultProcessingSystem.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }  // Primary key for DB
        public long Registration { get; set; }  // Student registration number
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Session { get; set; }
    }
}
