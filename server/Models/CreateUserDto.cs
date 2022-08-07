using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(16)]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Bio { get; set; }
        public string? Avatar { get; set; }
    }
}
