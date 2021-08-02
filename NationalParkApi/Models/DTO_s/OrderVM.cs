

using System.Collections.Generic;

namespace NationalParkApi.Models.DTO_s
{
    public class OrderVM
    {
        public string Name { get; set; }
        public List<FamilyVM> Families { get; set; }

        public OrderVM(Order order)
        {
            Name = order.Name;
            Families = new List<FamilyVM>();
            foreach (var family in order.Families)
            {
                Families.Add(new FamilyVM(family));
            }
        }
    }
}
