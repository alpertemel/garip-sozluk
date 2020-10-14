using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class RegisterVM
    {
        //public readonly object ValidationErrors;

        public RegisterVM()
        {

        }

        [Required(ErrorMessage = "UserName zorunludur")]
        [Display(Name = "UserName")]
        [DataType(DataType.Text)]
        public string  Username { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }


        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler aynı olmalıdır.")]
        public string ConfirmPassword { get; set; }

    }
}
