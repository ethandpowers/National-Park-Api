using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models.DTO_s
{
    public class SpeciesVM
    {
        public string SpeciesID { get; set; }
        public string Park { get; set; }
        public string Category { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string ScientificName { get; set; }
        public string RecordStatus { get; set; }
        public string Occurance { get; set; }
        public string Nativeness { get; set; }
        public string Abundance { get; set; }
        public string Seasonality { get; set; }
        public string ConservationStatus { get; set; }
        public List<CommonNameVM> CommonNames { get; set; }

        public SpeciesVM(Species species)
        {
            SpeciesID = species.Species_ID;
            Park = species.Park;
            Category = species.Category;
            Order = species.Order;
            Family = species.Family;
            ScientificName = species.Scientific_Name;
            RecordStatus = species.Record_Status;
            Occurance = species.Occurance;
            Nativeness = species.Nativeness;
            Abundance = species.Abundance;
            Seasonality = species.Seasonality;
            ConservationStatus = species.Conservation_Status;

            CommonNames = new List<CommonNameVM>();
            foreach(var name in species.Common_Names)
            {
                CommonNames.Add(new CommonNameVM(name));
            }
        }


    }
}
