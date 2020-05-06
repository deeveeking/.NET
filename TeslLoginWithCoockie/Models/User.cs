using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeslLoginWithCoockie.Models
{
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public double AllLiters { get; set; }
        public double Bonus { get; set; }

    }
}
