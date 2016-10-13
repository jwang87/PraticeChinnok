using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity;                            //RoleManager
using Microsoft.AspNet.Identity.EntityFramework;            //IdentityRole, RoleStore
#endregion

namespace ChinookSystem.Security
{
    public class RoleManager : RoleManager<IdentityRole>
    {
        public RoleManager() : base(new RoleStore<IdentityRole>(new ApplicationDbContext()))
        {

        }

        //this method will be excuted when the application starts up
        //under IIS
        public void AddStartupRoles()
        {
            foreach (string rolename in SecurityRoles.StartupSecurityRoles)
            {
                //check if the role already exists in the Security Tables
                //located in the database
                if (!Roles.Any(r => r.Name.Equals(rolename)))
                {
                    //role is not currently in the database
                    this.Create(new IdentityRole(rolename));
                }
            }
        }
    }
}
