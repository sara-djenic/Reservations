using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit_asp.Models
{
    public class Court
    {
        public int CourtId { get; set; }
        public string Name { get; set; }
        public CourtType CourtType { get; set; }
        public byte CourtTypeId { get; set; }
        
    }
}