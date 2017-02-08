using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    public class HousingUnitDTO
    {
        public string HousingUnitName { get; set; }
        public string AptNumber { get; set; }
        public int MaxCapacity { get; set; }
        public string GenderName { get; set; }
        public string HousingComplexName { get; set; }

    }
}
