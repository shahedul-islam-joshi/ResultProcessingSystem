using System.ComponentModel.DataAnnotations;

namespace ResultProcessingSystem.Models.ViewModel
{
    public class AddStudentRequest
    {
        public int Id { get; set; }
        public long Registration { get; set; }
        [Required]
        public string? Department { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? session { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Date { get; set; }

        [Display(Name = "Upload Picture")]
        public IFormFile? ProfileImage { get; set; }
    }
}