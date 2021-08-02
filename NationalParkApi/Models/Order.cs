using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Family> Families { get; set; }

        public Order()
        {
            Families = new List<Family>();
        }
    }
}
