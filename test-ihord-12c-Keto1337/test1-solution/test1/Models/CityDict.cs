using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.Models
{
    public class CityDict
    {

        public CityDict()
        {
            Flights = new HashSet<Flight>();
        }

        public int IdCityDict { get; set; }
        public string City { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
