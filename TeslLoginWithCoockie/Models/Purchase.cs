using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeslLoginWithCoockie.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int FuelId { get; set; }
        public string FuelName { get; set; }
        public Fuel Fuel { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Liters { get; set; }
        public DateTime PurchaseTime { get; set; }


    }
}
