using System.ComponentModel.DataAnnotations;

namespace JWPROJECT.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? admin_email { get; set; }

        [Required]
        public string? admin_password { get; set; }
    }
}
