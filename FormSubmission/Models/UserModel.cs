using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string FirstName{get; set;}
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string LastName{get; set;}
        [Required]
        [Range(1,128)]
        public int Age{get; set;}
        [Required]
        [EmailAddress]
        [MaxLength(64)]
        public string Email{get; set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password{get; set;}
    }
}