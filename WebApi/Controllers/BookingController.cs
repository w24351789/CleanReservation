using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.BookApp;
using Domain;
using MediatR;
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
        
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateBooking(CreateBooking.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{bookingId}")]
        public async Task<ActionResult<Unit>> DeleteBooking(Guid bookingId)
        {
            return await Mediator.Send(new DeleteBooking.Command { BookingId = bookingId});
        }
    }
}