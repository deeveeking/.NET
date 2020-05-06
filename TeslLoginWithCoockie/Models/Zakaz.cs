using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeslLoginWithCoockie.Models
{
    public class Zakaz { 
    
        public int Id { get; set; }
        public int Liters { get; set; }
        public double Price { get; set; }
        public string FuelName { get; set; }
        public int SuppliersId { get; set; }
        public Suppliers Suppliers { get; set; }

    }
}
