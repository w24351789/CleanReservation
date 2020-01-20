using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ReservationPeriodApp;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ReservationPeriodController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<ReservationPeriod>>> GetReservationPeriods()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{reservationperiodId}")]
        public async Task<ActionResult<ReservationPeriod>> GetReservationPeriod(Guid reservationperiodId)
        {
            return await Mediator.Send(new Details.Query { ReservationPeriodId = reservationperiodId });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateReservationPeriod(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{reservationperiodId}")]
        public async Task<ActionResult<Unit>> EditReservationPeriod(Guid reservationperiodId, Edit.Command command)
        {
            command.Id = reservationperiodId;
            return await Mediator.Send(command);
        }

        [HttpDelete("{reservationperiodId}")]
        public async Task<ActionResult<Unit>> DeleteReservationPeriod(Guid reservatonperiodId)
        {
            return await Mediator.Send(new Delete.Command { ReservationPeriodId = reservatonperiodId });
        }
    }
}