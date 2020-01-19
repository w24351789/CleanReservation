using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ReservationPeriodApp;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateReservationPeriod(Create.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}