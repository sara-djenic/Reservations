using Ispit_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit_asp.ViewModels
{
    public class NewCourtViewModel
    {
        public IEnumerable<CourtType> CourtTypes { get; set; }
        public Court Court { get; set; }
    }
}