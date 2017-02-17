using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
#pragma warning disable CS1591
    public class BatchDTO
    {
        [Required]
        [StringLength(100,ErrorMessage ="Length must be between 12 and 100.",MinimumLength = 12)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string Instructor { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "Length must be between 2 and 75.", MinimumLength = 2)]
        public string Technology { get; set; }
    }
}
