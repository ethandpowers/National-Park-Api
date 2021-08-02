using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models.DTO_s
{
    public class ActivityVM
    {
        public string activity { get; set; }

        public ActivityVM(Activity act)
        {
            activity = act.activity;
        }
    }
}
