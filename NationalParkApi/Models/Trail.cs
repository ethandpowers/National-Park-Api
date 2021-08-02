
using System.Collections.Generic;

namespace NationalParkApi.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string trailID { get; set; }
        public string name { get; set; }
        public string areaName { get; set; }
        public string cityName { get; set; }
        public string stateName { get; set; }
        public double popularity { get; set; }
        public double length { get; set; }
        public double elevation { get; set; }
        public int difficultyRating { get; set; }
        public string routeType {get;set;}
        public int visitorUsage { get; set; }
        public double avgRating { get; set; }
        public int numReviews { get; set; }
        public List<Feature> features { get; set; }
        public List<Activity> activities { get; set; }
        public string units { get; set; }

        public Trail()
        {
            this.features = new List<Feature>();
            this.activities = new List<Activity>();
        }
    }
}
