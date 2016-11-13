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
    [Table("Tracks")]
    public class Track
    {
        //entity validation
        //this is a validation that kicks in when the
        //.SaveChange() command is executed
        //[Required(ErrorMessage="xxx")]
        //[StringLength(int max[, int min], ErrorMessage="xxx")]
        //[Range(double min, double max, ErrorMessage="xxx")]
        //[RegularExpression("expression", ErrorMessage ="xxx")]
        [Key]
        public int TrackId { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid album, try again")]
        public int? AlbumId { get; set; }
        [Required(ErrorMessage = "Media type is a required field")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid media type, try again")]
        public int MediaTypeId { get; set; }
        [Required(ErrorMessage = "Genre is a required field")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Genre type, try again")]
        public int? GenreId { get; set; }
        [StringLength(200, ErrorMessage = "Name of composer cannot exceed 200 characters")]
        public string composer { get; set; }
        [Required(ErrorMessage = "Milliseconds is a required field")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid milliseconds, must be greater then zero")]
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        [Required(ErrorMessage = "Unit price is a required field")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid unit price, must be greater than or equal to zero")]
        public decimal UnitPrice { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual MediaType MediaTypes { get; set; }
        public virtual Album Albums { get; set; }
        public virtual Genre Genres { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
