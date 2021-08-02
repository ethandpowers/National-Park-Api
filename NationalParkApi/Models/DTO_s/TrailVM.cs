using System.Collections.Generic;

namespace NationalParkApi.Models.DTO_s
{
    public class TrailVM
    {
        public string trailID { get; set; }
        public string name { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public double popularity { get; set; }
        public double length { get; set; }
        public double elevationChange { get; set; }
        public int difficultyRating { get; set; }
        public string routeType { get; set; }
        public int visitorUsage { get; set; }
        public double avgRating { get; set; }
        public int numReviews { get; set; }
        public List<FeatureVM> features { get; set; }
        public List<ActivityVM> activities { get; set; }
        public string units { get; set; }

        public TrailVM(Trail trail)
        {
            trailID = trail.trailID;
            name = trail.name;
            area = trail.areaName;
            city = trail.cityName;
            state = trail.stateName;
            popularity = trail.popularity;
            length = trail.length;
            elevationChange = trail.elevation;
            difficultyRating = trail.difficultyRating;
            routeType = trail.routeType;
            visitorUsage = trail.visitorUsage;
            avgRating = trail.avgRating;
            numReviews = trail.numReviews;
            units = trail.units;
            features = new List<FeatureVM>();
            activities = new List<ActivityVM>();
            foreach (Feature feat in trail.features)
            {
                features.Add(new FeatureVM(feat));
            }
            foreach (Activity act in trail.activities)
            {
                activities.Add(new ActivityVM(act));
            }
        }
    }
}
