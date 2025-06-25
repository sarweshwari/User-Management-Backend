using System.ComponentModel.DataAnnotations;

namespace BackendDotNet.Dto
{
    public class RegisterDto
    {
        
        [Required]
        public string? UserName {  get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public DateOnly? Birthdate { get; set; }
       
    }
}
