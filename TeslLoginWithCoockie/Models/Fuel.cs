using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeslLoginWithCoockie.Models
{
    public class Fuel
    {
        public int Id { get; set; }
        public int Liters { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

    }
}
