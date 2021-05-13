using System.Collections.Generic;

namespace Kinder_Backend.Models
{
    public class TravelResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public List<Travel> TravelDetail { get; set; }
    }
}