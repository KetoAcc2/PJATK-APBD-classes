using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.Models
{
    public class Passenger
    {

        public Passenger()
        {
            FlightPassengers = new HashSet<FlightPassenger>();
        }

        public int IdPassenger { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNum { get; set; }

        public virtual ICollection<FlightPassenger> FlightPassengers { get; set; }
    }
}
