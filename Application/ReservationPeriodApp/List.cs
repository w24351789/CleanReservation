using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReservationPeriodApp
{
    public class List
    {
        public class Query : IRequest<List<ReservationPeriod>>
        {
            
        }

        public class Handler : IRequestHandler<Query, List<ReservationPeriod>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ReservationPeriod>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reservationPeriods = await _context.ReservationPeriods.ToListAsync();

                return reservationPeriods;
            }
        }
    }
}
