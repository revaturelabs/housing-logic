using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    public class HousingDataDTO
    {
        public int HousingDataId { get; set; }
        public int AssociateId { get; set; }
        public int HousingUnitId { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
    }
}
