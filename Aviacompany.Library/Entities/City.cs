using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aviacompany.Library.Entities
{
    public class City
    {
        public int CityId { get; set; }

        [Display(Name = "Город")]
        public string CityName { get; set; }

        public virtual ICollection<Flight> FlightsFrom { get; set; }

        public virtual ICollection<Flight> FlightsTo { get; set; }
    }
}