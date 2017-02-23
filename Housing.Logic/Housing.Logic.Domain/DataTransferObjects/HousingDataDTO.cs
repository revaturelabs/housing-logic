using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Logic.Domain.CustomAnnotations;

namespace Housing.Logic.Domain.DataTransferObjects
{
#pragma warning disable CS1591
    public class HousingDataDTO
    {
        [Required]
        [EmailAddress]
        public string AssociateEmail { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100", MinimumLength = 2)]
        public string HousingUnitName { get; set; }

        [Required]
        [DateTimeNotMinValue]
        public DateTime MoveInDate { get; set; }

        [Required]
        [DateTimeNotMinValue]
        public DateTime MoveOutDate { get; set; }
        
        public string HousingDataAltId { get; set; }
    }
}
