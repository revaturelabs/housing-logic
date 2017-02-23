using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Housing.Logic.Domain.CustomAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    #pragma warning disable CS1591
    public class AssociateDTO
    {
        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100,ErrorMessage ="Length must be between 2 and 100.",MinimumLength =2)]
        public string FirstName { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string GenderName { get; set; }

        [Required]
        [NotEmptyStringOrWhiteSpaceOrNull]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string BatchName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]  
        [DateTimeNotMinValue]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool? HasCar { get; set; }

        [Required]
        public bool? HasKeys { get; set; }

        [Required]
        public bool? NeedsHousing { get; set; }
    }
}
