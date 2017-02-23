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
    public class BatchDTO
    {
        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100,ErrorMessage ="Length must be between 12 and 100.",MinimumLength = 12)]
        public string Name { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string Instructor { get; set; }

        [Required]
        [DateTimeNotMinValue]
        public DateTime StartDate { get; set; }

        [Required]
        [DateTimeNotMinValue]
        public DateTime EndDate { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(75, ErrorMessage = "Length must be between 2 and 75.", MinimumLength = 2)]
        public string Technology { get; set; }
    }
}
