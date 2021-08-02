using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models.DTO_s
{
    public class FamilyVM
    {
        public string Name { get; set; }
        public List<SpeciesVM> Species { get; set; }

        public FamilyVM(Family fam)
        {
            Name = fam.Name;
            Species = new List<SpeciesVM>();
            foreach(var species in fam.Species)
            {
                Species.Add(new SpeciesVM(species));
            }
        }
    }
}
