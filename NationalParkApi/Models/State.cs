using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static string getAbbreviation(string state)
        {
            if (state == "Alabama")
            {
                return "AL";
            }else if (state == "Alaska")
            {
                return "AK";
            }
            else if (state == "American Samoa")
            {
                return "AS";
            }
            else if (state == "Arizona")
            {
                return "AZ";
            }
            else if (state == "Arkansas")
            {
                return "AR";
            }
            else if (state == "California")
            {
                return "CA";
            }
            else if (state == "Colorado")
            {
                return "CO";
            }
            else if (state == "Connecticut")
            {
                return "CT";
            }
            else if (state == "Delaware")
            {
                return "DE";
            }
            else if (state == "District of Columbia")
            {
                return "DC";
            }
            else if (state == "Florida")
            {
                return "FL";
            }
            else if (state == "Georgia")
            {
                return "GA";
            }
            else if (state == "Guam")
            {
                return "GU";
            }
            else if (state == "Hawaii")
            {
                return "HI";
            }
            else if (state == "Idaho")
            {
                return "ID";
            }
            else if (state == "Illinois")
            {
                return "IL";
            }
            else if (state == "Indiana")
            {
                return "IN";
            }
            else if (state == "Iowa")
            {
                return "IA";
            }
            else if (state == "Kansas")
            {
                return "KS";
            }
            else if (state == "Kentucky")
            {
                return "KY";
            }
            else if (state == "Louisiana")
            {
                return "LA";
            }
            else if (state == "Maine")
            {
                return "MN";
            }
            else if (state == "Maryland")
            {
                return "MD";
            }
            else if (state == "Massachusetts")
            {
                return "MA";
            }
            else if (state == "Michigan")
            {
                return "MI";
            }
            else if (state == "Minnesota")
            {
                return "MN";
            }
            else if (state == "Mississippi")
            {
                return "MS";
            }
            else if (state == "Missouri")
            {
                return "MO";
            }
            else if (state == "Montana")
            {
                return "MT";
            }
            else if (state == "Nebraska")
            {
                return "NE";
            }
            else if (state == "Nevada")
            {
                return "NV";
            }
            else if (state == "New Hampshire")
            {
                return "NH";
            }
            else if (state == "New Jersey")
            {
                return "NJ";
            }
            else if (state == "New Mexico")
            {
                return "NM";
            }
            else if (state == "New York")
            {
                return "NY";
            }
            else if (state == "North Carolina")
            {
                return "NC";
            }
            else if (state == "North Dakota")
            {
                return "ND";
            }
            else if (state == "Ohio")
            {
                return "OH";
            }
            else if (state == "Oklahoma")
            {
                return "OK";
            }
            else if (state == "Oregon")
            {
                return "OR";
            }
            else if (state == "Pennsylvania")
            {
                return "PA";
            }
            else if (state == "Puerto Rico")
            {
                return "PR";
            }
            else if (state == "Rhode Island")
            {
                return "RI";
            }
            else if (state == "South Carolina")
            {
                return "SC";
            }
            else if (state == "South Dakota")
            {
                return "SD";
            }
            else if (state == "Tennessee")
            {
                return "TN";
            }
            else if (state == "Texas")
            {
                return "TX";
            }
            else if (state == "Utah")
            {
                return "UT";
            }
            else if (state == "Vermont")
            {
                return "VT";
            }
            else if (state == "Virginia")
            {
                return "VA";
            }
            else if (state == "Virgin Islands")
            {
                return "VI";
            }
            else if (state == "Washington")
            {
                return "WA";
            }
            else if (state == "West Virginia")
            {
                return "WV";
            }
            else if (state == "Wisconsin")
            {
                return "WI";
            }
            else if (state == "Wyoming")
            {
                return "WY";
            }
            else
            {
                return state;
            }
        }
    }
}
