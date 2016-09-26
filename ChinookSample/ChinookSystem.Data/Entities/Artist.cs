using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalSpaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ChinookSystem.Data.Entities
{
    [Table("Artists")]
    public class Artist
    {
        //Key notation is optional if the sql pkey
        //ends in ID or Id
        //required if default of entity is NOT Identity
        //required if pkey is compound
        
        //Properties can be full implemented or auto implemented
        //Properties name should use sql attributes name
        //Properties should be listed in the same order as sql table attributes for ease of maintenance      
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        
        //navigation properties for use by Linq
        //these properties will be of type virtual
        public virtual ICollection<Album> Albums { get; set; }

    }
}
