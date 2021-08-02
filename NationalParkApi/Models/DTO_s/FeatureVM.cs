
namespace NationalParkApi.Models.DTO_s
{
    public class FeatureVM
    {
        public string feature { get; set; }
        public FeatureVM(Feature feat)
        {
            feature = feat.feature;
        }
    }
}
