using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    public class HousingDataDTO
    {
        public string AssociateEmail { get; set; }
        public string HousingUnitName { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime MoveOutDate { get; set; }
        public string HousingDataAltId { get; set; }
    }
}
