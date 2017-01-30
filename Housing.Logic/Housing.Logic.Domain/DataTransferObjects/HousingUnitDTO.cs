using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    public class HousingUnitDTO
    {
        public int HousingUnitId { get; set; }
        public string AptNumber { get; set; }
        public int MaxCapacity { get; set; }
        public string Gender { get; set; }
        public int HousingComplexId { get; set; }
    }
}
