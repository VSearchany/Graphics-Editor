using System.ComponentModel.DataAnnotations;

namespace Realt.Models
{
    public class RegisterModel : LoginModel
    {
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}