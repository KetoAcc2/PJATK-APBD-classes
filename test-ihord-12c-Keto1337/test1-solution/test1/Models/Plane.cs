using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.Models
{
    public class Plane
    {

        public Plane()
        {
            Flights = new HashSet<Flight>();
        }
        public int IdPlane { get; set; }
        public string Name { get; set; }
        public int MaxSeats { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
