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
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        //navigation properties for use by Linq
        //these properties will be of type virtual
        //there are two types of navigation properties
        //properties that point "children" use ICollection<T>
        //properties that point to "Parent" use ParentName as
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Artist Artists { get; set; }



    }
}
