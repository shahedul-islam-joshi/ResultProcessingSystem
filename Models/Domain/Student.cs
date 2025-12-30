using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResultProcessingSystem.Models.Domain
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public long Registration { get; set; }
        public string? Department { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
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

        [Display(Name = "Profile Picture")]
        public byte[]? ProfilePicture { get; set; }

        [NotMapped]
        [Display(Name = "Upload Picture")]
        public IFormFile? ProfileImage { get; set; }
    }
}