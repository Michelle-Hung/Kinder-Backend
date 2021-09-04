using System;

namespace Kinder_Backend.Models
{
    public class TravelList
    {
        public int Id { get; set; }
        public string Attraction { get; set; }
        // public string Address { get; set; }
        // public string Context { get; set; }
        public DateTime StartDate { get;  set; }
        // public DateTime EndDate { get; internal set; }
        // public DateTime CreatedOn { get; internal set; }
        // public DateTime ModifiedOn { get; internal set; }
        public string PictureName {get; set;}
    }
}