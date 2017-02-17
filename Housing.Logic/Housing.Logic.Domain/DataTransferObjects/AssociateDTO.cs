using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    #pragma warning disable CS1591
    public class AssociateDTO
    {
        [Required]
        [StringLength(100,ErrorMessage ="Length must be between 2 and 100.",MinimumLength =2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string GenderName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string BatchName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Length must be between 7 and 20.", MinimumLength = 7)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]        
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool HasCar { get; set; }

        [Required]
        public bool HasKeys { get; set; }

        [Required]
        public bool NeedsHousing { get; set; }
    }
}
