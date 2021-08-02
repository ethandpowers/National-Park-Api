using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Models.DTO_s
{
    public class CommonNameVM
    {
        public string Name { get; set; }

        public CommonNameVM(CommonName name)
        {
            Name = name.Name;
        }
    }
}
