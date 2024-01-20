using System.ComponentModel.DataAnnotations;

namespace webhoa.ViewModel
{
    public class UserDetails
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
