using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
#pragma warning disable CS1591
    public class HousingDataDTO
    {
        [Required]
        [EmailAddress]
        public string AssociateEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100", MinimumLength = 2)]
        public string HousingUnitName { get; set; }

        [Required]
        public DateTime MoveInDate { get; set; }

        [Required]
        public DateTime MoveOutDate { get; set; }
        
        public string HousingDataAltId { get; set; }
    }
}
