using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Species_ID { get; set; }
        public string Park { get; set; }
        public string Category { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Scientific_Name { get; set; }
        public List<CommonName> Common_Names { get; set; }
        public string Record_Status { get; set; }
        public string Occurance { get; set; }
        public string Nativeness { get; set; }
        public string Abundance { get; set; }
        public string Seasonality { get; set; }
        public string Conservation_Status { get; set; }

        public Species()
        {
            Common_Names = new List<CommonName>();
        }
    }
}
