using System.Collections.Generic;

namespace NationalParkApi.Models.DTO_s
{
    public class ParkVM
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Acres { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<StateVM> States { get; set; }
        public List<CategoryVM> Categories { get; set; }

        public ParkVM(Park park)
        {
            Code = park.Code;
            Name = park.Name;
            Acres = park.Acres;
            Latitude = park.Latitude;
            Longitude = park.Longitude;

            States = new List<StateVM>();
            foreach(var state in park.States)
            {
                States.Add(new StateVM(state));
            }

            Categories = new List<CategoryVM>();
            foreach (var cat in park.Categories)
            {
                Categories.Add(new CategoryVM(cat));
            }
        }
    }
}
