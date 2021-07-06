using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ispit_asp.Models
{
    public class Court
    {
        [Key][Required]
        public int CourtId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required"), MaxLength(128)]
        public string Name { get; set; }
        public CourtType CourtType { get; set; }
        public byte CourtTypeId { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}