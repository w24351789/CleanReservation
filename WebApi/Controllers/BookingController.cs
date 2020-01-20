using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BookApp;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class BookingController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetBookings()
        {
            return await Mediator.Send(new GetBookings.Query());
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<Booking>> GetBooking(Guid bookingId)
        {
            return await Mediator.Send(new GetBooking.Query { BookingId = bookingId });
        }

        [HttpPost("availablejaintor")]
        public async Task<ActionResult<List<Jaintor>>> GetAvailableJaintorByTime(GetAvailableJaintorByTime.Query query)
        {
            return await Mediator.Send(query);
        }
    }
}