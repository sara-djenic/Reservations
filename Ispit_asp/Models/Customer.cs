using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ispit_asp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required"), MaxLength(128)]
        public string CustomerName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}