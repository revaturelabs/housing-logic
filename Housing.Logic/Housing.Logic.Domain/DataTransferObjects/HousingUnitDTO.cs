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
    public class HousingUnitDTO
    {
        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string HousingUnitName { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(25, ErrorMessage = "Length must be between 1 annd 25.", MinimumLength = 1)]
        public string AptNumber { get; set; }

        [Required]
        [Range(1,20, ErrorMessage = "Range must be between 1 and 20.")]
        public int MaxCapacity { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string GenderName { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string HousingComplexName { get; set; }

        [Required]
        [DateTimeNotMinValue]
        public DateTime LeaseEndDate { get; set; }

    }
}
