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
using ChinookSystem.Data.Entities;
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
        #region Constants
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
                                                 CustomerEmployeeId = emp.EmployeeId,
                                                 FirstName = emp.FirstName,
                                                 LastName = emp.LastName,
                                                 UserType = UnRegisteredUserType.Employee
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
                                                 CustomerEmployeeId = cus.CustomerId,
                                                 FirstName = cus.FirstName,
                                                 LastName = cus.LastName,
                                                 UserType = UnRegisteredUserType.Customer
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
                UserName = userInfo.AssignedUserName,
                Email = userInfo.AssignedEmail
            };
            switch (userInfo.UserType)
            {
                case UnRegisteredUserType.Customer:
                    {
                        newuseraccount.CustomerId = userInfo.CustomerEmployeeId;
                        break;
                    }
                case UnRegisteredUserType.Employee:
                    {
                        newuseraccount.EmployeeId = userInfo.CustomerEmployeeId;
                        break;
                    }
            }

            //create the actual AspNetUser record
            this.Create(newuseraccount, STR_DEFAULT_PASSWORD);

            //assign the user to the appropriate role
            switch (userInfo.UserType)
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

        //List all current users
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UserProfile> ListAllUsers()
        {
            //we will be using the RoleManager to get roles
            var rm = new RoleManager();

            //get the current users off the User security table
            var results = (from person in Users.ToList()
                           select new UserProfile
                           {
                               UserId = person.Id,
                               UserName = person.UserName,
                               Email = person.Email,
                               EmailConfirmed = person.EmailConfirmed,
                               CustomerId = person.CustomerId,
                               EmployeeId = person.EmployeeId,
                               RoleMembership = person.Roles.Select(r => rm.FindById(r.RoleId).Name)
                           }).ToList();
            //using our own data tables, gather the user FirstName and LastName
            using (var context = new ChinookContext())
            {
                Employee etemp;
                Customer cIemp;

                foreach(var person in results)
                {
                    if(person.EmployeeId.HasValue)
                    {
                        etemp = context.Employees.Find(person.EmployeeId);
                        person.FirstName = etemp.FirstName;
                        person.LastName = etemp.LastName;
                    }
                    else if(person.CustomerId.HasValue)
                    {
                        cIemp = context.Customers.Find(person.EmployeeId);
                        person.FirstName = cIemp.FirstName;
                        person.LastName = cIemp.LastName;
                    }
                    else
                    {
                        person.FirstName = "unkown";
                        person.LastName = "";
                    }
                    string a = results.ElementAt(2).FirstName;
                }
            }

            return results;
        }
        //Add an user to the User Table (listview)
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddUser(UserProfile userInfo)
        {
            var userAccount = new ApplicationUser()
            {
                UserName = userInfo.UserName,
                Email = userInfo.Email
            };

            //create the new user on the physical Users Table
            this.Create(userAccount, STR_DEFAULT_PASSWORD);

            //create the UserProfiles which were chosen at insert time
            foreach(var roleName in userInfo.RoleMembership)
            {
                this.AddToRole(userAccount.Id, roleName);
            }
        }
        //delete an user from the User Table (listview)
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void RemoveUser(UserProfile userInfo)
        {
            //bussiness rule
            //the webmaster cannot be deleted

            //Realize that the only infomation you have at this time
            //is the DataKeyName value which is the User ID
            //(on the user security table the field is Id)

            //obtain the username from the security talbe user table using
            //the User ID value

            string UserName = this.Users.Where(u => u.Id == userInfo.UserId)
                .Select(u => u.UserName).SingleOrDefault().ToString();

            //remove the user
            if(UserName.Equals(STR_WEBMASTER_USERNAME))
            {
                throw new Exception("The webmaster account cannot be deleted");
            }

            this.Delete(this.FindById(userInfo.UserId));
        }

    }//eoc

}//eon
