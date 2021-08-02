using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models
{
    public class Park
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Acres { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<State> States { get; set; }
        public List<Category> Categories { get; set; }

        public Park()
        {
            Categories = new List<Category>();
            States = new List<State>();
        }
    }
}
