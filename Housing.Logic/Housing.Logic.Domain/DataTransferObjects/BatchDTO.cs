using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    public class BatchDTO
    {
        public int BatchId { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Technology { get; set; }
    }
}
