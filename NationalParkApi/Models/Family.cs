﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Species> Species { get; set; }

        public Family()
        {
            Species = new List<Species>();
        }
    }
}
