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
    [Table("PlaylistTracks")]
    public class PlaylistTrack
    {
        [Key]
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
