using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using System.Data.Entity;
using ChinookSystem.Data.Entities;
#endregion

namespace ChinookSystem.DAL
{
    //internal class for security resons
    //access restricted to withinthe component library
    //inherit DbContext for Entiry Framework requires
    internal class ChinookContext : DbContext
    {
        //pass the connection string name to the
        //DbContext using :base
        public ChinookContext() : base("ChinookDB")
        {

        }

        //Setup DbSet properties
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
