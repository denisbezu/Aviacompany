using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aviacompany.Library.Entities
{
    public class FlightStatus
    {
        public int FlightStatusId { get; set; }
        [Display(Name = "Статус рейса")]
        public string StatusName { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}