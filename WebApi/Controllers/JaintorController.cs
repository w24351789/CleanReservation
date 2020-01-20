using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.JaintorApp;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class JaintorController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Jaintor>>> GetJaintors()
        {
            return await Mediator.Send(new GetJaintors.Query());
        }

        [HttpGet("{jaintorId}")]
        public async Task<ActionResult<Jaintor>> GetJaintor(Guid jaintorId)
        {
            return await Mediator.Send(new GetJaintor.Query { JaintorId = jaintorId });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateJaintor(CreateJaintor.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{jaintorId}")]
        public async Task<ActionResult<Unit>> EditJaintor(Guid jaintorId, EditJaintor.Command command)
        {
            command.Id = jaintorId;
            return await Mediator.Send(command);
        }

        [HttpDelete("{jaintorId}")]
        public async Task<ActionResult<Unit>> DeleteJaintor(Guid jaintorId)
        {
            return await Mediator.Send(new DeleteJaintor.Command { JaintorId = jaintorId });
        }

        [HttpGet("{jaintorId}/reservationperiod")]
        public async Task<ActionResult<List<ReservationPeriod>>> GetReservationPeriodByJaintor(Guid jaintorId)
        {
            return await Mediator.Send(new GetReservationPeriodByJaintor.Query { JaintorId = jaintorId });
        }

        [HttpGet("booking/{jaintorId}")]
        public async Task<ActionResult<List<Booking>>> GetBookingByJaintor(Guid jaintorId)
        {
            return await Mediator.Send(new GetBookingByJaintor.Query { JaintorId = jaintorId });
        }
    }
}