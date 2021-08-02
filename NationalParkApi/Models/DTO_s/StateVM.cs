using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models.DTO_s
{
    public class StateVM
    {
        public string Name { get; set; }

        public StateVM(State state)
        {
            Name = state.Name;
        }
    }
}
