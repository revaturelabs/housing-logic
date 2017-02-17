using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
#pragma warning disable CS1591
    public class GenderDTO
    {
        [Required]
        [StringLength(100,ErrorMessage ="Length must be between 2 and 100.",MinimumLength =2)]
        public string Name { get; set; }
    }
}
