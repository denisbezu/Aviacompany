using System.ComponentModel.DataAnnotations;

namespace Aviacompany.Library.Models
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^.+@.+\\..+", ErrorMessage = "Неверный email адрес")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}