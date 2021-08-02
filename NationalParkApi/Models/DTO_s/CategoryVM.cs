using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models.DTO_s
{
    public class CategoryVM
    {
        public string Name { get; set; }
        public List<OrderVM> Orders { get; set; }

        public CategoryVM(Category cat)
        {
            Name = cat.Name;

            Orders = new List<OrderVM>();
            foreach(var order in cat.Orders)
            {
                Orders.Add(new OrderVM(order));
            }
        }
    }
}
