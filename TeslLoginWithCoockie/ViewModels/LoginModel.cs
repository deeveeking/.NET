using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeslLoginWithCoockie.ViewModels
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Не указан Е-мейл")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

    }
}
