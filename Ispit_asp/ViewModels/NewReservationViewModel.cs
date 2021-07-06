using Ispit_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit_asp.ViewModels
{
    public class NewReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public IEnumerable<Court> Courts{ get; set; }
    }
}