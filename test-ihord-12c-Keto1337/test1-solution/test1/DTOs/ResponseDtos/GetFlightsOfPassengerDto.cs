using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.DTOs.ResponseDtos
{
    public class GetFlightsOfPassengerDto
    {

        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        public string? Comments { get; set; }
        public string City { get; set; }
        public string Plane { get; set; }

    }
}
