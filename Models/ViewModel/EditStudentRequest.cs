using System.ComponentModel.DataAnnotations;

namespace ResultProcessingSystem.Models.ViewModel
{
    public class EditStudentRequest
    {
        public int Id { get; set; }
        public long Registration { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Session is required")]
        public string? session { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Date { get; set; }

        public byte[]? ProfilePicture { get; set; }

        [Display(Name = "Update Picture")]
        public IFormFile? ProfileImage { get; set; }
    }
}