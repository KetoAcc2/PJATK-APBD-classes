using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.Models
{
    public class FlightPassenger
    {

        public int IdFlight { get; set; }
        public int IdPassenger { get; set; }

        public virtual Flight IdFlightNavigation { get; set; }
        public virtual Passenger IdPassengerNavigation { get; set; }
    }
}
