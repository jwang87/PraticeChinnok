using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity.EntityFramework; //UserStore
using Microsoft.AspNet.Identity;
using System.ComponentModel;
using ChinookSystem.DAL;
#endregion


namespace ChinookSystem.Security
{
    [DataObject]
    public class UserManager : UserManager<ApplicationUser>//inherited userManager that inherits from ApplicationUser
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }


        //setting up the default webManager
        #region
        private const string STR_DEFAULT_PASSWORD = "Pa$$word1";
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        private const string STR_EMAIL_FORMAT = "{0}@Chinook.ca";
        private const string STR_WEBMASTER_USERNAME = "webmaster";
        #endregion

        public void AddWebMaster()
        {
            if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var webMasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                //this create command is from the inherited UserManager class
                //this command creates a record on the security User table (AspNetUsers)
                this.Create(webMasterAccount, STR_DEFAULT_PASSWORD);
                //this AddToRole command is from the inherited UserManager class
                //this command creats a record on the security UserRole talbe (AspNetUserRoles)
                this.AddToRole(webMasterAccount.Id, SecurityRoles.WebsiteAdmin);
            }

        }//eom

        //create the crud methods for adding the user to the security user table
        //read of data to display on gridview
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UnregisteredUserProfile> ListAllUnregisteredUsers()
        {
            using (var context = new ChinookContext())
            {
                //the data needs to be in memory for execution by the next query
                //to complish this use .ToList() which will force the query to execute

                //List() set contianing the list of employeeids
                var registeredEmployees = (from emp in Users
                                           where emp.EmployeeId.HasValue
                                           select emp.EmployeeId).ToList();
                //compare the List() set to the user data table Employees
                var unregisteredEmployees = (from emp in context.Employees
                                             where !registeredEmployees.Any(eid => emp.EmployeeId == eid)
                                             select new UnregisteredUserProfile
                                             {
                                                 UserId = emp.EmployeeId,
                                                 FirstName = emp.FirstName,
                                                 LastName = emp.LastName,
                                                 UserTpye = UnRegisteredUserType.Employee
                                             }).ToList();
                //List() set contianing the list of customerid
                var registeredCustomers = (from cus in Users
                                           where cus.CustomerId.HasValue
                                           select cus.CustomerId).ToList();
                //compare the List() set to the user data table Cutomers
                var unregisteredCustomers = (from cus in context.Customers
                                             where !registeredCustomers.Any(cid => cus.CustomerId == cid)
                                             select new UnregisteredUserProfile
                                             {
                                                 UserId = cus.CustomerId,
                                                 FirstName = cus.FirstName,
                                                 LastName = cus.LastName,
                                                 UserTpye = UnRegisteredUserType.Customer
                                             }).ToList();

                return unregisteredEmployees.Union(unregisteredCustomers).ToList();


            }
        }//eom
        //register an user to the User Table (gridview)
        public void RegisterUser(UnregisteredUserProfile userInfo)
        {
            //basic infomation needed for the security user record
            //password, email, username
            //you could ramdomly generate a password, we will use the default password
            //the instance of the required user is based on our ApplicationUser
            var newuseraccount = new ApplicationUser()
            {
                UserName = userInfo.UserName,

            };
            switch (userInfo.UserTpye)
            {
                case UnRegisteredUserType.Customer:
                    {
                        newuseraccount.Id = userInfo.UserId.ToString();
                        break;
                    }
                case UnRegisteredUserType.Employee:
                    {
                        newuseraccount.Id = userInfo.UserId.ToString();
                        break;
                    }
            }

            //create the actual AspNetUser record
            this.Create(newuseraccount, STR_DEFAULT_PASSWORD);

            //assign the user to the appropriate role
            switch (userInfo.UserTpye)
            {
                case UnRegisteredUserType.Customer:
                    {
                        this.AddToRole(newuseraccount.Id, SecurityRoles.RegisteredUsers);
                        break;
                    }
                case UnRegisteredUserType.Employee:
                    {
                        this.AddToRole(newuseraccount.Id, SecurityRoles.Staff);
                        break;
                    }
            }


        }//eom
        //Add an user to the User Table (listview)

        //delete an user from the User Table (listview)

    }//eoc

}//eon
