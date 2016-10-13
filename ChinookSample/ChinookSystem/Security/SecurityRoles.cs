using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
    internal static class SecurityRoles
    {
        public const string WebsiteAdmin = "WebsiteAdmin";
        public const string RegisteredUsers = "RegisteredUsers";
        public const string Staff = "Staff";
        public const string Auditor = "Auditor";

        //ReadOnly
        public static List<string> StartupSecurityRoles
        {
            get
            {
                List<string> rolelist = new List<string>();
                rolelist.Add(WebsiteAdmin);
                rolelist.Add(RegisteredUsers);
                rolelist.Add(Staff);
                rolelist.Add(Auditor);
                return rolelist;
            }
        }
    }
}
