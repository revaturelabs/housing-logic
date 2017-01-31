using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Logic.Domain.DataTransferObjects
{
    public class AssociateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public string BatchName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool HasCar { get; set; }
        public bool HasKeys { get; set; }
    }
}
