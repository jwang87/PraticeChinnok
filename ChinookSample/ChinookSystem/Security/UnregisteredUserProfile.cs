using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
    public enum UnRegisteredUserType
    {
        Undifined,
        Employee,
        Customer
    }
    public class UnregisteredUserProfile
    {
        public string UserId { get; set; } //generated when added
        public string UserName { get; set; } //collected
        public string FirstName { get; set; } //comes from the user table
        public string LastName { get; set; } //comes from the user table
        public string Email { get; set; } //collected
        public UnRegisteredUserType UserTpye { get; set; }

    }
}
