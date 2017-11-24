using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aviacompany.Library.Entities
{
    public class Flight
    {
        [HiddenInput(DisplayValue = false)]
        public int FlightId { get; set; }
        [Display(Name = "Номер рейса")]
        public string FlightNumber { get; set; }

        public int? FlightFrom { get; set; }

        public City FlightFromCity { get; set; }

        public int? FlightTo { get; set; }

        public City FlightToCity { get; set; }
        [Display(Name = "Дата вылета")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy} HH:mm")]
        public DateTime FlightDateTime { get; set; }

        public int FlightStatusId { get; set; }

        public FlightStatus FlightStatus { get; set; }
    }
}
