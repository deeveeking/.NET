using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeslLoginWithCoockie.Models
{
    public class Suppliers
    {

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int FuelId { get; set; }
        public string FuelName { get; set; }
        public Fuel Fuel { get; set; }
        public double Price { get; set; }
    }
}
