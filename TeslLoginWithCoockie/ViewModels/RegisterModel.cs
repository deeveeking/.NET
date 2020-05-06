using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeslLoginWithCoockie.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Е-мейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Имя не указано")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия не указана")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен не верно")]
        public string ConfirmPassword { get; set; }



    }
}
