using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.Models
{
    public class Flight
    {

        public Flight()
        {
            FlightPassengers = new HashSet<FlightPassenger>();
        }

        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        public string? Comments { get; set; }
        public int IdPlane { get; set; }
        public int IdCityDict { get; set; }

        public virtual Plane IdPlaneNavigation { get; set; }
        public virtual CityDict IdCityDictNavigation { get; set; }

        public virtual ICollection<FlightPassenger> FlightPassengers { get; set; }

    }
}
