using System.ComponentModel.DataAnnotations;

namespace FairWorks.Models.DTOs
{
    public class RegisterDTO
    {

        [Required(ErrorMessage = "Kullanıcı adı zorunludur!")]
        [Display(Name = "Kullanıcı Adı")]
        [MinLength(2, ErrorMessage = "Kullanıcı adı en az 2 karakter olabilir!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alani zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email alani zorunludur!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "email adresini yanliş giridiniz")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "TC Kimlik Numarası")]
        public string TcNo { get; set; }

    }
}
