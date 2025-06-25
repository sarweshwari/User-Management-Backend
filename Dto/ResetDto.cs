using System.ComponentModel.DataAnnotations;

namespace BackendDotNet.Dto
{
    public class ResetDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
