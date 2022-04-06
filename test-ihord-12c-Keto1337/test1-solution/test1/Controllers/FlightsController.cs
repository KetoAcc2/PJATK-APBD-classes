using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test1.Services;

namespace test1.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IDatabaseService databaseService;

        public FlightsController(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlightsOfPassenger(int IdPassenger)
        {
            var exists = await databaseService.IdPassengerExists(IdPassenger);
            if (!exists)
                return StatusCode(404, "Passenger with such Id does not exist!");

            var hasFlights = await databaseService.IdPassengerHasFlights(IdPassenger);
            if (!hasFlights)
                return StatusCode(400, "Passenger with such Id does not have any flights!");

            var result = await databaseService.GetFlightsOfPassenger(IdPassenger);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPassengerOnFlight(int IdPassenger, int IdFlight)
        {
            var IdPassengerExists = await databaseService.IdPassengerExists(IdPassenger);
            if (!IdPassengerExists)
                return StatusCode(404, "Passenger with such Id does not exist!");

            var IdFlightExists = await databaseService.IdPassengerExists(IdFlight);
            if (!IdFlightExists)
                return StatusCode(404, "Flight with such Id does not exist!");

            var notStarted = await databaseService.FlightIsNotStarted(IdFlight);
            if (!notStarted)
                return StatusCode(400, "Flight with such Id has already taken place!");

            var limitNotExceeded = await databaseService.LimitOnPlaneNotExceeded(IdFlight);
            if (!limitNotExceeded)
                return StatusCode(400, "Flight with such Id has all seats taken!");

            var isRegistered = await databaseService.PassengerIsRegisteredForThisFlight(IdPassenger, IdFlight);
            if (isRegistered)
                return StatusCode(400, "Passenger with such Id has already been assigned to flight with such Id!");

            await databaseService.AssignPassengerToFlight(IdPassenger, IdFlight);
            return StatusCode(200, "Passenger was succesfully assigned to the flight!");
        }
    }
}
