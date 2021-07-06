using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit_asp.Models
{
    public enum TimeSlots
    {
       _10h, _12h, _14h, _16h, _18h
    }
    

    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CourtId { get; set; }
        public int CustomerId { get; set; }
        public TimeSlots TimeSlots { get; set; }

        public virtual Court Court { get; set; }
        public virtual Customer Customer { get; set; }
    }
}